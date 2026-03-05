# Hướng dẫn Deploy Backend lên Railway

## Bước 1: Chuẩn bị
1. Tạo tài khoản tại https://railway.app (dùng GitHub để login)
2. Install Railway CLI (optional): `npm i -g @railway/cli`

## Bước 2: Tạo Project trên Railway
1. Vào Railway Dashboard
2. Click "New Project"
3. Chọn "Deploy from GitHub repo" hoặc "Empty Project"

## Bước 3: Thêm MySQL Database
1. Trong project, click "New" → "Database" → "Add MySQL"
2. Railway sẽ tự động tạo database và cung cấp connection string
3. Copy các biến môi trường: `MYSQLHOST`, `MYSQLPORT`, `MYSQLDATABASE`, `MYSQLUSER`, `MYSQLPASSWORD`

## Bước 4: Deploy Backend
### Cách 1: Deploy từ GitHub (Recommended)
1. Push code lên GitHub repository
2. Trong Railway project, click "New" → "GitHub Repo"
3. Chọn repository `Mitalab_be`
4. Railway sẽ tự động detect Dockerfile và build

### Cách 2: Deploy từ CLI
```bash
cd Mitalab_be
railway login
railway init
railway up
```

## Bước 5: Cấu hình Environment Variables
Trong Railway project settings, thêm các biến:

```
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=Server=${{MYSQLHOST}};Port=${{MYSQLPORT}};Database=${{MYSQLDATABASE}};User=${{MYSQLUSER}};Password=${{MYSQLPASSWORD}};
```

Railway sẽ tự động thay thế `${{MYSQLHOST}}` bằng giá trị thực.

## Bước 6: Cập nhật CORS
Sau khi deploy, Railway sẽ cung cấp URL (vd: `https://your-app.railway.app`)
- Cập nhật CORS trong code để cho phép frontend domain
- Hoặc set environment variable `FRONTEND_URL`

## Lưu ý
- Free tier: $5 credit/tháng (~500 hours)
- Database sẽ sleep sau 1 giờ không hoạt động (free tier)
- Có thể upgrade lên paid plan nếu cần

## Alternative: Render.com
Nếu muốn dùng Render (free tier tốt hơn):
1. Tạo tài khoản tại https://render.com
2. New → Web Service → Connect GitHub
3. Chọn repo và configure:
   - Environment: Docker
   - Instance Type: Free
4. Add MySQL database (hoặc dùng external như PlanetScale)
