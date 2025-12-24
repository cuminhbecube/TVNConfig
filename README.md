# TVNConfigSW - Phần mềm cấu hình thiết bị giám sát hành trình TVN

## Tổng quan dự án

TVNConfigSW là phần mềm ứng dụng Windows desktop được phát triển bằng C# WinForms, chuyên dụng để cấu hình, giám sát và cập nhật firmware cho các thiết bị giám sát hành trình GPS của hãng DSS, bao gồm các dòng sản phẩm: **TVN02, TVN05, TVN06, TVN08**.

Phần mềm kết nối với thiết bị thông qua cổng **COM Serial** (RS232/USB), cho phép người dùng thực hiện đầy đủ các chức năng cấu hình, theo dõi trạng thái thiết bị, xem log hoạt động và cập nhật firmware từ xa.

**Nhà phát triển:** DSS (www.dss.com.vn)  
**Tác giả:** Mai Truong Giang  
**Phiên bản:** 1.1.1.116  
**Bản quyền:** © 2017-2018 DSS

---

## Kiến trúc và thành phần dự án

### 1. Cấu trúc mã nguồn

Dự án được tổ chức theo kiến trúc WinForms với các module chính:

```
TVNConfigSW/
├── FrmMain.cs                    # Form chính - giao diện điều khiển
├── BootloaderProcessing.cs       # Xử lý cập nhật firmware qua bootloader
├── ModbusCRC16.cs                # Tính toán CRC16 Modbus cho kiểm tra gói tin
├── ListBoxLog.cs                 # Hiển thị log với màu sắc theo mức độ
├── IntervalPacket.cs             # Định nghĩa các loại gói tin truyền nhận
├── Debugging.cs                  # Công cụ debug và hiển thị lỗi API
├── DebuggingDeclarations.cs      # Khai báo API cho debugging
├── FrmDeviceSetting.Designer.cs  # Form cài đặt thiết bị
├── FrmFirmwareUpdate.Designer.cs # Form cập nhật firmware
└── AssemblyInfo.cs               # Thông tin phiên bản và metadata
```

### 2. Các lớp và chức năng chính

#### **FrmMain** - Form chính của ứng dụng
- Quản lý kết nối Serial Port với thiết bị
- Hiển thị thời gian thực log từ thiết bị (GPS, GPRS, Error logs)
- Gửi các lệnh cấu hình AT Command
- Theo dõi trạng thái GPS, GPRS/4G, pin, nhiệt độ, IO
- Xuất log sang file Excel/TXT

#### **BootloaderProcessing** - Xử lý cập nhật firmware
Lớp này quản lý toàn bộ quy trình cập nhật firmware qua bootloader với các chức năng:

- **Đọc file firmware binary**: Phân tích file firmware (.bin), trích xuất thông tin phiên bản từ marker string đặc biệt
- **Phân chia gói tin**: Chia firmware thành các gói tin 2048 byte, mỗi gói bao gồm:
  - Header: `0x7E` + Length(2) + `$B`(2) + Serial(2) + MessageCode(1)
  - Firmware Version(4) + TotalPacket(2) + PacketNo(2) + PayloadLength(2)
  - Payload Data(0-2048 bytes) + CRC16(2) + `0x0D0A`(2)
- **Xác thực gói tin**: Sử dụng CRC16 Modbus để đảm bảo tính toàn vẹn dữ liệu
- **Quản lý trạng thái**: State machine với các trạng thái:
  - `IDLE`: Chờ lệnh
  - `WAITING_DEVICE_BOOTUP`: Chờ thiết bị khởi động
  - `SEND_CMD_ERASE`: Gửi lệnh xóa flash
  - `SEND_NEXT_DATAPACKET`: Gửi từng gói dữ liệu firmware

**Cấu trúc gói tin bootloader:**
```
Message Code 1 (Init):    Packet đầu tiên, không chứa payload, thông báo bắt đầu
Message Code 2 (Data):    Các packet chứa dữ liệu firmware (2048 bytes/packet)
Message Code 3 (End):     Packet cuối cùng, không chứa payload, hoàn tất
```

#### **ModbusCRC16** - Tính toán checksum
- Sử dụng thuật toán Modbus CRC16
- Đảm bảo tính toàn vẹn của gói tin truyền/nhận
- Bảng tra CRC 256 phần tử để tính toán nhanh

#### **ListBoxLog** - Hiển thị log phân màu
- Hiển thị log theo 6 mức độ: Critical, Error, Warning, Info, Verbose, Debug
- Mỗi mức có màu sắc riêng để dễ phân biệt
- Hỗ trợ copy log ra clipboard dạng RTF
- Tự động cuộn theo log mới (có thể tạm dừng)
- Giới hạn số dòng tối đa (mặc định 500) để tránh tràn bộ nhớ

#### **IntervalPacket** - Định nghĩa giao thức
Các loại gói tin được hỗ trợ:
- `Interval`: Gói tin dữ liệu định kỳ từ thiết bị
- `Login`: Gói tin đăng nhập thiết bị với server
- `TextMessage`: Tin nhắn văn bản
- `GprsCommand`: Lệnh điều khiển qua GPRS
- `Fota`: Cập nhật firmware qua mạng (Firmware Over The Air)

---

## Giao thức truyền thông

### 1. Kết nối Serial Port
```
- Port: COM1-COM255 (tự động quét)
- Baud Rate: 9600, 19200, 38400, 57600, 115200
- Data Bits: 8
- Stop Bits: 1
- Parity: None
- Flow Control: None
```

### 2. Lệnh AT Commands
Phần mềm hỗ trợ gửi các lệnh cấu hình tiêu chuẩn:

**Lệnh hệ thống:**
- `*TVN686,993#` - Khởi động lại vào chế độ bootloader
- `*300190,990,099#` - Reset về cấu hình mặc định
- `*300190,500#` - Xóa toàn bộ flash
- `*300190,991#` - Reset thiết bị

**Cấu hình TVN02:**
```
*000000,001,300190#              # Đặt mật khẩu
*300190,011,e-connect,,#         # Cấu hình APN
*300190,015,1,gps.tracking.vn,18860# # Cấu hình server
*300190,016,1,#                  # Kích hoạt kết nối
*300190,018,30,999#              # Cài đặt interval gửi dữ liệu
```

**Cấu hình TVN05:**
```
*000000,001,300190#
*300190,011,e-connect,,#
*300190,015,1,gps.tracking.vn,20022# # Port khác với TVN02
*300190,016,1,#
*300190,018,30,999#
```

### 3. Định dạng log từ thiết bị
Thiết bị gửi log theo dòng, các loại thông tin:
- **GPS Status**: Vị trí, vận tốc, số vệ tinh, HDOP
- **GPRS Status**: Cường độ sóng (CSQ), trạng thái kết nối
- **System Info**: Điện áp pin, nhiệt độ (TempA/B/C/D), IO status
- **Error Messages**: Lỗi phần cứng, lỗi kết nối

---

## Tính năng chính

### 1. Quản lý kết nối thiết bị
- ✅ Tự động quét các cổng COM khả dụng
- ✅ Hỗ trợ nhiều tốc độ baud rate
- ✅ Hiển thị trạng thái kết nối realtime
- ✅ Tự động nhận diện thiết bị kết nối

### 2. Giám sát thiết bị theo thời gian thực
- ✅ **GPS**: Vị trí, tốc độ, hướng, số vệ tinh, độ chính xác
- ✅ **GPRS/4G**: Cường độ sóng (CSQ), trạng thái kết nối mạng
- ✅ **System**: 
  - Điện áp pin (VBAT)
  - Nhiệt độ 4 cảm biến (TempA, TempB, TempC, TempD)
  - Trạng thái IO (Digital Input/Output)
  - Trạng thái nguồn điện
- ✅ **Device Info**: IMEI, Firmware Version, Bootloader Version, ICCID (SIM)

### 3. Cấu hình thiết bị
- ✅ Thiết lập server và port kết nối
- ✅ Cấu hình APN cho GPRS
- ✅ Thiết lập chu kỳ gửi dữ liệu
- ✅ Cấu hình các preset: TVN02, TVN05
- ✅ Reset về cài đặt mặc định
- ✅ Xóa flash memory

### 4. Cập nhật Firmware
- ✅ Đọc và xác thực file firmware binary
- ✅ Trích xuất tự động phiên bản firmware
- ✅ Chia nhỏ firmware thành gói tin 2KB
- ✅ Kiểm tra tính toàn vẹn bằng CRC16
- ✅ Hiển thị tiến trình cập nhật (progress bar)
- ✅ Xử lý lỗi và retry tự động
- ✅ Timeout protection cho từng gói tin

### 5. Quản lý Log
- ✅ Hiển thị log realtime với màu sắc phân cấp
- ✅ Tự động cuộn hoặc dừng cuộn
- ✅ Lọc hiển thị GPS sentence (NMEA)
- ✅ Copy log ra clipboard
- ✅ Xuất log sang Excel (.xlsx)
- ✅ Xuất log sang Text (.txt)
- ✅ Lưu log theo IMEI thiết bị
- ✅ Xóa log trong bộ nhớ

### 6. Phân tích gói tin
- ✅ Parser gói tin hex string
- ✅ Hiển thị cấu trúc gói tin chi tiết
- ✅ Decode các trường thông tin

---

## Yêu cầu hệ thống

### Phần cứng tối thiểu
- **CPU**: Intel Core 2 Duo hoặc tương đương
- **RAM**: 2 GB
- **Ổ cứng**: 100 MB dung lượng trống
- **Cổng COM**: RS232 hoặc USB-to-Serial adapter

### Phần mềm
- **Hệ điều hành**: Windows Vista SP2 trở lên (Vista, 7, 8, 10, 11)
- **.NET Framework**: 4.8 trở lên
- **Quyền truy cập**: Administrator (để truy cập COM port)

### Thư viện phụ thuộc
- **EPPlus 5.8.8**: Thư viện xuất Excel (OpenXML)
- **Microsoft.IO.RecyclableMemoryStream 1.4.1**: Quản lý memory hiệu quả
- **System.ComponentModel.Annotations 4.7.0**: Data annotations
- **Microsoft.Office.Interop.Excel**: COM Interop với Excel (tùy chọn)

---

## Hướng dẫn cài đặt

### 1. Cài đặt từ source code

#### Yêu cầu môi trường phát triển
- **Visual Studio 2012** trở lên (khuyến nghị VS 2019 hoặc 2022)
- **.NET Framework 4.8 SDK**
- **NuGet Package Manager**

#### Các bước build
```bash
# 1. Clone repository
git clone https://gitlab.com/dss-tvn02/tvnconfigsw.git
cd tvnconfigsw

# 2. Restore NuGet packages
nuget restore TVNConfigSW.sln

# 3. Build solution
msbuild TVNConfigSW.sln /p:Configuration=Release /p:Platform="Any CPU"

# Hoặc build trong Visual Studio:
# - Mở file TVNConfigSW.sln
# - Chọn Build > Build Solution (Ctrl+Shift+B)
# - File .exe sẽ được tạo tại: bin/Release/TVNConfigSW.exe
```

### 2. Cài đặt driver USB-to-Serial
Nếu sử dụng cáp USB-to-Serial, cần cài đặt driver:
- **FTDI**: https://ftdichip.com/drivers/
- **Prolific**: https://www.prolific.com.tw/
- **CH340**: Driver tích hợp sẵn trong Windows 10+

### 3. Chạy ứng dụng
```bash
# Chạy từ command line
cd bin/Release
TVNConfigSW.exe

# Hoặc double-click vào file TVNConfigSW.exe
```

---

## Hướng dẫn sử dụng

### Bước 1: Kết nối thiết bị
1. Kết nối thiết bị TVN với máy tính qua cáp COM/USB
2. Chờ Windows nhận diện cổng COM (kiểm tra trong Device Manager)
3. Mở phần mềm TVNConfigSW
4. Click **"Refresh"** để quét danh sách cổng COM
5. Chọn cổng COM và Baud Rate phù hợp (thường là **115200**)
6. Click **"Open"** để kết nối

### Bước 2: Xem log thiết bị
- Log thiết bị sẽ hiển thị tự động trong tab **"Device Logs"**
- Tick **"Auto Scroll"** để tự động cuộn theo log mới
- Tick **"Display GPS Sentence"** để hiển thị câu lệnh NMEA GPS
- Click **"Clear Logs"** để xóa log hiển thị

### Bước 3: Cấu hình thiết bị
1. Chuyển sang tab **"Device Settings"**
2. Chọn preset cấu hình:
   - Click **"TVN02"** cho thiết bị TVN02
   - Click **"TVN05"** cho thiết bị TVN05
3. Hoặc nhập lệnh AT command thủ công vào ô **"Command List"**
4. Click **"Write Settings"** để gửi cấu hình

### Bước 4: Cập nhật Firmware
1. Chuyển sang tab **"Firmware Update"**
2. Click **"Open File"** và chọn file firmware (.bin)
3. Phần mềm sẽ tự động đọc và hiển thị phiên bản firmware
4. Click **"Reboot to DFU Mode"** để khởi động thiết bị vào chế độ bootloader
5. Đợi thiết bị khởi động lại (khoảng 5 giây)
6. Progress bar sẽ hiển thị tiến trình cập nhật
7. Khi hoàn tất, thiết bị sẽ tự động reset

**⚠️ Lưu ý quan trọng khi cập nhật firmware:**
- KHÔNG ngắt kết nối trong quá trình cập nhật
- Đảm bảo thiết bị có đủ nguồn điện
- Sử dụng file firmware chính xác cho model thiết bị
- Nếu cập nhật thất bại, thử lại hoặc liên hệ hỗ trợ kỹ thuật

### Bước 5: Xuất Log
1. Click **"Export TXT"** để xuất log dạng text
2. Click **"Export Excel"** để xuất log dạng Excel
3. File sẽ được lưu với tên theo IMEI và timestamp

---

## Cấu trúc dữ liệu và thuật toán

### 1. Bootloader Protocol Flow
```
[PC]                          [Device]
  |                               |
  |-- Reboot to Bootloader ------>|
  |                               |
  |<------ ACK (Ready) ----------|
  |                               |
  |-- Init Packet (Code 1) ------>|
  |   (FW Ver, Total Packets)     |
  |<------ ACK --------------------|
  |                               |
  |-- Data Packet 1 (Code 2) ----->|
  |   (2048 bytes + CRC)          |
  |<------ ACK --------------------|
  |                               |
  |-- Data Packet 2 (Code 2) ----->|
  |<------ ACK --------------------|
  |                               |
  |       ... (continue) ...      |
  |                               |
  |-- End Packet (Code 3) -------->|
  |<------ ACK --------------------|
  |                               |
  |<------ Device Reboot ---------|
```

### 2. CRC16 Modbus Algorithm
```csharp
// Tính CRC16 cho mảng byte
// wCRCTable là bảng tra 256 phần tử được định nghĩa trong ModbusCRC16.cs
UInt16 wCRCWord = 0xFFFF;
for (int i = offset; i < offset + length; i++)
{
    byte nTemp = (byte)(data[i] ^ wCRCWord);
    wCRCWord >>= 8;
    wCRCWord ^= wCRCTable[nTemp];  // Tra bảng để tính CRC nhanh
}
return wCRCWord;
```

### 3. Serial Port Data Processing
```
Thread 1 (Serial Port):
  - Nhận data từ COM port
  - Đưa vào ConcurrentQueue

Thread 2 (Timer - 100ms):
  - Lấy data từ Queue
  - Parse thành từng dòng (kết thúc bởi \r\n)
  - Phân loại: GPS/GPRS/Error/System
  - Cập nhật UI
```

---

## Khắc phục sự cố

### Lỗi "Cannot open COM port"
- **Nguyên nhân**: Cổng COM đã được sử dụng bởi ứng dụng khác
- **Giải pháp**: 
  - Đóng các ứng dụng terminal khác (PuTTY, Arduino IDE, etc.)
  - Kiểm tra Device Manager xem driver đã cài đúng chưa
  - Thử rút và cắm lại cáp USB

### Không nhận được log từ thiết bị
- **Nguyên nhân**: Sai baud rate hoặc thiết bị chưa khởi động
- **Giải pháp**:
  - Thử các baud rate khác: 9600, 38400, 115200
  - Reset thiết bị và thử lại
  - Kiểm tra cáp kết nối

### Cập nhật firmware thất bại
- **Nguyên nhân**: Mất kết nối, file firmware sai, timeout
- **Giải pháp**:
  - Kiểm tra kết nối COM port ổn định
  - Đảm bảo file firmware đúng với model thiết bị
  - Tăng timeout trong code nếu cần thiết
  - Khởi động lại thiết bị và thử lại

### Ứng dụng bị crash khi xuất Excel
- **Nguyên nhân**: Thiếu thư viện EPPlus hoặc quyền ghi file
- **Giải pháp**:
  - Restore NuGet packages
  - Chạy ứng dụng với quyền Administrator
  - Kiểm tra đường dẫn thư mục output

---

## Đóng góp và phát triển

### Quy tắc coding
- Tuân thủ C# Coding Conventions của Microsoft
- Sử dụng English cho tên biến/hàm, Vietnamese cho comment
- Mỗi hàm không quá 100 dòng code
- Bắt exception đầy đủ

### Quy trình đóng góp
1. Fork repository
2. Tạo branch mới: `git checkout -b feature/ten-tinh-nang`
3. Commit thay đổi: `git commit -m "Thêm tính năng X"`
4. Push lên branch: `git push origin feature/ten-tinh-nang`
5. Tạo Pull Request

### Roadmap phát triển
- [ ] Hỗ trợ cập nhật firmware qua FOTA (Firmware Over The Air)
- [ ] Kết nối TCP/IP trực tiếp với thiết bị qua GPRS
- [ ] Quản lý nhiều thiết bị đồng thời
- [ ] Database lưu trữ lịch sử cấu hình
- [ ] Export log dạng CSV
- [ ] Giao diện đa ngôn ngữ (EN/VI)
- [ ] Hỗ trợ thiết bị TVN mới (TVN09, TVN10)

---

## Tác giả và bản quyền

**Công ty:** DSS - Digital Security Solutions  
**Website:** www.dss.com.vn  
**Tác giả chính:** Mai Truong Giang  
**Email hỗ trợ:** support@dss.com.vn  

**Bản quyền:** © 2017-2018 DSS. All rights reserved.

### Giấy phép
Phần mềm này là sản phẩm thương mại của DSS. Mọi hành vi sao chép, phân phối hoặc sử dụng cho mục đích thương mại mà không có sự cho phép của DSS đều bị nghiêm cấm.

---

## Thông tin liên hệ

Để được hỗ trợ kỹ thuật và thông tin chi tiết về sản phẩm:
- **Website:** www.dss.com.vn
- **Email:** support@dss.com.vn

_Vui lòng liên hệ qua website hoặc email để được hỗ trợ trực tiếp._

---

## Lịch sử phiên bản

### Version 1.1.1.116 (Current)
- Ổn định giao diện người dùng
- Cải thiện thuật toán bootloader
- Hỗ trợ xuất log Excel với EPPlus 5.8.8
- Tối ưu hiệu suất xử lý serial data

### Version 1.0.x
- Phiên bản đầu tiên
- Các tính năng cơ bản

