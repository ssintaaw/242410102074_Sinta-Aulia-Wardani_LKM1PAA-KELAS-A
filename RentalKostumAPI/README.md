# RENTAL KOSTUM API
a. Deskripsi project
   Project ini merupakan REST API untuk sistem rental kostum. 
   API ini digunakan untuk mengelola data pelanggan, kostum, dan transaksi penyewaan. 
   Sistem ini dibuat untuk memenuhi kebutuhan pengolahan data secara terstruktur 
   menggunakan database relasional serta mendukung operasi CRUD (Create, Read, Update, Delete).
   Domain yang dipilih adalah Rental Kostum karena memiliki relasi data yang jelas antara pelanggan, 
   kostum, dan transaksi penyewaan.

b. Teknologi yang digunakan
- Bahasa Pemrograman: C#
- Framework: ASP.NET Core Web API
- Database: PostgreSQL
- Library Database: Npgsql
- Tools: Visual Studio, pgAdmin, Swagger

c. Langkah instalasi dan running project
- Buka Visual Studio
- Pilih Create a new project
- Pilih ASP.NET Core Web API
  Beri nama project: RentalKostumAPI
- Klik Next → Create
- Tambahkan package PostgreSQL:
  Klik Tools → NuGet Package Manager → Manage NuGet Packages
- Install: Npgsql
- Buat folder: Models, Services, Controllers
- Buat file model, service, dan controller sesuai kebutuhan
- Atur connection string pada file appsettings.json
- Jalankan project dengan menekan tombol Run
- Buka Swagger di browser


d. Import database
- Buka aplikasi pgAdmin
- Pilih server PostgreSQL
- Klik kanan pada Databases, pilih Create, Database
  Masukkan nama database: RentalKostumJember
- Klik Save
- Klik database yang sudah dibuat → pilih Query Tool
- Buka file database.sql dari project
- Copy seluruh isi file tersebut
- Paste ke Query Tool
- Klik tombol Execute

e. Daftar endpoint
| Method |        URL        |         Keterangan            |
|--------|-------------------|-------------------------------|
| GET    | /api/rentals      | Mengambil semua data rental   |
| GET    | /api/rentals/{id} | Mengambil data berdasarkan ID |
| POST   | /api/rentals      | Menambahkan data rental       |
| PUT    | /api/rentals/{id} | Mengupdate data rental        |
| DELETE | /api/rentals/{id} | Menghapus data (soft delete)  |

f. Link video presentasi: https://youtu.be/nhHlzcCQdUs?si=39ujE2T2ppkrF2pa
