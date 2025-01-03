Để có thể chạy bên trong thư mục bạn phải cấp quyền cho certs
dotnet dev-certs https -ep certs\cert.pfx -p yourpassword // Tạo chứng chỉ phát triển
dotnet dev-certs https --trust // Cấp quyền tin tưởng cho chứng chỉ
icacls "C:\Users\sonb1\source\repos\SafeBrowserServer\certs\cert.pfx" // Tìm tới đường dẫn này trong thư mục máy bạn để cung cấp quyền đọc cho chứng chỉ
Import Chứng Chỉ
  - Chọn Local Machine hoặc Current User.
  - Nhập mật khẩu bạn đã đặt khi tạo chứng chỉ.
  - Chọn Place all certificates in the following store.
  - Chọn Trusted Root Certification Authorities.
  - Hoàn tất và xác nhận import chứng chỉ.
