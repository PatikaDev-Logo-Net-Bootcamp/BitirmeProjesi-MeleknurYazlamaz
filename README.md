# Patika.dev & Logo Yazılım .NET Core Bootcamp Bitirme Projesi : Invoice Management System
## Proje Tanımı
Bir sitede yer alan dairelerin, aidat ve ortak kullanım; elektrik, su ve doğalgaz faturalarının yönetimini 
gerçekleştirebildiğimiz bir sistemdir. Bu sistemde iki tip kullanıcı vardır:

### 1- Admin/Yönetici
✔️ Daire bilgilerini girebilir.  
✔️ İkamet eden kullanıcı bilgilerini girer.  
✔️ Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek tek atama yapılabilir.  
✔️ Gelen ödeme bilgilerini görür.  
❌ Gelen mesajları görür.  
❌ Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.  
✔️ Aylık olarak borç-alacak listesini görür.  
✔️ Kişileri listeler, düzenler, siler.  
✔️ Daire/konut bilgilerini listeler, düzenler siler.  

### 2-Kullanıcı
✔️ Kendisine atanan fatura ve aidat bilgilerini görür.  
✔️ Sadece kredi kartı ile ödeme yapabilir.  
❌ Yöneticiye mesaj gönderebilir.  
❌ Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.  
✔️ Yaptığı ödemelerini görür.  

### Daire/Konut bilgilerinde:
● Hangi blokda ● Durumu (Dolu-boş) ● Tipi (2+1 vb.) ● Bulunduğu kat bulunur.

### Kullanıcı bilgilerinde:
● Ad-soyad ● TCNo ● E-Mail ● Telefon ● Araç bilgisi(varsa plaka no) bulunur.

### Kredi Kartı ile Ödeme Servisi:
❌ Sistemdeki her bir kullanıcı için banka bilgileri (bakiye, kredi kartı no vb.) kontrol edilerek ödeme yapılması sağlanır.  
✔️ Ödeme sadece kredi kartı ile yapılabilir.  
✔️ Veriler MongoDB'de tutulmalı. Servis .Net WebApi olarak yazılacaktır.  

---

## Projede Kullanılan Teknolojiler
- Backend: .Net Core - C# | Frontend: Razor
- Sistemin yönetimi/database: MS SQL Server - MongoDB

---

## Tamamlanan Modüller ve Uygulama Ekran Görüntüleri

✔ Kullanıcıların sisteme erişimi için "Giriş" ve "Kayıt" ekranları oluşturulmuştur.    
![Login_Page](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Login_Page.png)  
![Register_Page](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Register_Page.png)

---

✔ "Ana Sayfa" üzerinden diğer sayfalara ulaşılabilir.
![Home_Page](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Home_Page.png)

---

✔ Yönetici, "Apartmanlar" sayfasında; apartman bilgisi ekleme, listeleme, düzenleme ve silme işlemlerini yapabilir.
![Add_Apartment](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Add_Apartment.png)  
![Apartment_List](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Apartment_List.png) 

---

✔ Yönetici, "Daireler" sayfasında; daire/konut bilgisi ekleme, listeleme, düzenleme ve silme işlemlerini yapabilir.
![Add_House](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Add_House.png)  
![House_List](https://github.com/melekny/Invoice-Management-System/blob/main/Images/House_List.png)

---

✔ Yönetici, "Kullanıcılar" sayfasında; sitede ikamet eden kullanıcı bilgisi ekleme, listeleme, düzenleme ve silme işlemlerini yapabilir.  
![Add_Resident](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Add_Resident.png)  
![Resident_List](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Resident_List.png)  

---

✔ Yönetici, "Faturalar" sayfasında; fatura bilgisi ekleme, listeleme, düzenleme ve silme işlemlerini yapabilir.  
![Add_Invoice](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Add_Invoice.png)  
![Invoive_List](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Invoice_List.png)

---

✔ Yönetici, "Profilim" sayfasında; kullanıcı bilgilerini düzenleyebilir.
![Update_Profile](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Update_Profile.png)

---

✔ Kullanıcılar, "Faturalar" sayfasında; yönetici tarafından atanan fatura ve aidat bilgilerini görüntüleyebilirler.
![Payment_List](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Payment_List.png)

---

✔ Kullanıcılar, ödeme modülüyle; sadece kredi kartı ile ödeme yapabilir ve ödemelerini görüntüleyebilirler.  
![Invoice_Payment](https://github.com/melekny/Invoice-Management-System/blob/main/Images/Invoice_Payment.png)

---

## Eksik Modüller
❌ Mesajlaşma modülü tamamlanamadı.  
❌ Kredi kartı ile ödeme servisi için MongoDB bağlantısı yapılmış ve servis Web API şeklinde oluşturulmuştur.  
Postman ve Swagger üzerinden yapılan denemelerde, veri tabanı bağlantısı sorunsuz çalışmaktadır.
Ancak ödeme modülüyle yapılan denemelerde hatalar bulunmaktadır.