T.C. FIRAT ÜNİVERSİTESİ 
MÜHENDİSLİK FAKÜLTESİ - YAZILIM MÜHENDİSLİĞİ BÖLÜMÜ
BİTİRME ÖDEVİ PROJE ÖNERİSİ

YILI / DÖNEMİ	2021-2022 DERS YILI / BAHAR DÖNEMİ
ÖĞRENCİ NO	180290014
AD SOYAD	Caner Şermet
BİTİRME TEZ DANIŞMANI	Dr. Öğr. Üyesi Özgür KARADUMAN
PROJE KONUSU/BAŞLIĞI	Swagger API ile Çoklu Bulut Yönetim Otomasyonu
PROJENİN AMACI (Projenin amacı en fazla birkaç cümle ile net ifadelerle belirtilmelidir)
Bu çalışmada bir şirketin veya şahısın çoklu bulut sisteminin yönetim otomasyon aracı üzerinden yapmasını ve kendi cloud otomasyon yazılımını Swagger sayesinde API’lar üzerinden yapabilmeleri amaçlanmıştır.

MOTİVASYON (Bu projenin önemi nedir? Bu projeye duyulan ihtiyaç nereden kaynaklanmaktadır? )
Şirketlerin veya şahısların cloud sistemlerini yönetmesi için Google, Amazon, Azure gibi bulut şirketlerinin web sitelerinden yönetmesi veya çoklu bulut yönetim otomasyonları kullanmaları gerekiyor. Birden fazla bulut sisteminin tek bir otomasyon yazılımı ile kullanımı daha düzenli ve kolay bir şekilde sistemlerin yönetebilmesini sağlıyor. 
Büyük şirketler genellikle Vmware gibi şirketlerin çoklu bulut yönetim sistemlerini kullanıyorlar ancak bu sistemler oldukça maliyetli ve kurulumu zaman alıcı olabiliyor. Dolayısıyla maliyetli ve kurulumu zaman alıcı daha geniş kapsamlı cloud yönetimleri yerine daha az kapsamlı ve hızlı bir yönetim isteyen daha küçük çaplı şirketler veya şahıs kullanımı için uygun otomasyon yazılım yapılması gereklidir. 

 
Resim 1. İşletmelerin Bulut Stratejileri [1]

Şu an tüm işletmelerin %92’si çoklu bulut stratejisini benimsemektedir. Gelecekte ise, daha fazla işletmenin belirli bir bulut sağlayıcısına çok az veya hiç bağımlı olmadan çoklu bulut stratejileri geliştireceği öngörülmektedir [1]. 
Yazılan otomasyonun arka planındaki kodlara erişemeyiz. Dolayısıyla yazılan otomasyon kodları sadece o otomasyona özel olmuş olur. Yazılan otomasyon kodlarının başka otomasyon yazılımları için kullanılmasını istersek API kullanabiliriz ancak API kullansak bile yazdığım API kodlarını belgelemediğimiz sürece nasıl kullanılacağı bilinemez ve bu sebepten kullanılamaz. Dolayısıyla Swagger gibi API kodlarını belgeleyen yöntemler kullanılması faydalıdır.
PROBLEM TANIMI, ÖNERİLEN YÖNTEM ve ELDE EDİLMEK İSTENEN SONUÇ (Projede asıl çözülmesi gereken teknik problemler nelerdir? Bu problemlerin çözülmesi için önerilen yöntemler nelerdir? Projede sonuçta ne elde edilmesi beklenmektedir? Problem tanımı amaç ile karıştırılmamalıdır)
Problem Tanımı: Şirketlerin veya şahısların cloud sistemlerini Google, Amazon, Azure gibi cloud şirketlerinin web sitelerinden yönetmesi yerine tek otomasyon ile çoklu cloud sistemlerinin yönetilebilmesi.

Problem: Çoklu cloud sistemlerinin tek otomasyon üzerinden yönetilebilmesi.

Problem: Her bulut şirketinin farklı API dokümantasyonu olması ve hizmetleri olması.

Problem: Web API geliştirmede en önemli ihtiyaçlardan biri dokümantasyon ihtiyacıdır. Çünkü API metotlarının ne işe yaradığı ve nasıl kullanıldığı dokümantasyon içeresinde anlaşılır olması gerekir. API dokümantasyonunu el emeği ile yazmak hem zordur hem de güncel tutması imkansızdır [2].

Önerilen Yöntem:

			 
Resim 2. Multi-Cloud Yönetim Modeli

Son yılların en popüler bulut kavramlarından biri olan multicloud, birden fazla bulutun bir araya getirildiği sistemdir. Bu sayede bütün işlemler tek bir yerden yönetilebilir ve kontrol edilebilir [3]. Bulut şirketlerinin paylaştığı API’lar ile bulut sistemlerine erişiminin ve yönetilmesi sağlanabilir. 

API’lardan gelecek JSON formatlı veriler ayıklanarak düzenli bir şekilde kullanıcıya gösterilmesi. Kullanıcıdan alınacak bilgiler ile bulut sistemlerinde gerekli işlemlerin yapılması.

Yazılım geliştirme ortamı olarak:
C# web sitesi ve otomasyon yazılımı kodları için kullanılacaktır.
Visual Studio ortamında C# Form kullanılacaktır.
Visual Studio ortamında Asp.Net kullanılacaktır.
JSON kütüphanesi API isteklerinden gelecek veya gönderilecek verilerin dönüştürülmesi için kullanılacaktır.
Swagger kütüphanesi yazılan API’ları belgelemek ve web sitesini oluşturmak için kullanılacaktır.
HTTP kütüphanesi istek göndermek için kullanılacaktır.

Elde edilmek istenen sonuç:
Yapılan otomasyon aracının çoklu bulut platformlarını yönetebilmesi ve Swagger ile yazılan API kodlarının belgelenebilmesi 

PROJENIN KATKISI (Projenin kattığı yenilikler, güçlü yönleri, özellikleri, bilime katkısı (varsa) belirtilmelidir)
Çoklu veya tek bulut sisteminin yönetilebilmesi için Vmware çözümleri gibi yüksek bütçeli ve kurulması uzun zaman alan sistemler yerine küçük şirketler veya şahıslar için daha basit ve az maliyetli çoklu bulut yönetim yazılımı olması.

Başka şirketlerin veya şahısların kendi çoklu bulut otomasyon yazılımını yazabilmesi ve otomasyondan bağımsız API’lar ile yönetebilmesi veya test edebilmesi için Swagger belgelemeye sahip olması.
PROJE İŞ AKIŞI (Projenin iş parçacıkları ve çözümleri için zaman planlaması çubuk diyagram(gantt) ile belirtilmelidir) 
                    	 		Hafta                               Yapılan iş	1	2	3	4	5	6	7	8	9	10
Bulut Analizi										
Bulut API Analizi										
API Kodlarının Yazılması										
Ara yüz tasarımı										
Otomasyon kodlarının yazılması										
API ile Otomasyon Kodlarının Entegre Edilmesi										
Kodun Test Edilmesi ve Hataların Giderilmesi										
Swagger ile Web Sitesi Oluşturma										
Sonuç Değerlendirmesi										


PROJE GEREKSİNİMLERİ (Projede ihtiyaç duyulan donanım/yazılım araç gereçleri ve hangi iş parçacığında/modülünde kullanılacağı liste halinde yazılmalıdır )
•	C# yazılım dili – Asp.net web sitesi ve otomasyon yazılım kodları için kullanılacaktır.
•	Visual Studio ortamında C# Form kullanılacaktır.
•	Visual Studio ortamında Asp.Net kullanılacaktır.
•	JSON kütüphanesi – API isteklerinden gelecek veya gönderilecek verilerin dönüştürülmesi için kullanılacaktır.
•	Swagger kütüphanesi – Yazılan API’ları belgelemek ve web sitesini oluşturmak için kullanılacaktır.
•	HTTP kütüphanesi – Rest API istekleri göndermek için kullanılacaktır.
KAYNAKLAR (Öneride yer alan tüm alıntıların (yazı, resim, çizelge, kod vs) kaynakları referans numarası ile listelenmelidir)
[1]	https://cloudtalktime.com/dunyada-ve-turkiyede-gelecek-5-yilin-bulut-trendleri/
[2]	https://medium.com/android-t%C3%BCrkiye/swagger-nedir-ne-i%CC%87%C5%9Fe-yarar-e8c12a9e9e7f
[3]	https://www.teknotel.com/blog/multicloud-nedir/


DANIŞMAN ONAYI	
    .................................................................................	……... /…..… / 2022

KOMİSYON ONAYI

          Başkan                                                                                  Üye 1                                                                            Üye 2

