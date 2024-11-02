# E-ticaret Sipariş Yönetim Sistemi

Bu proje, **Domain-Driven Design (DDD)** yaklaşımı kullanılarak geliştirilmiş bir **E-ticaret Sipariş Yönetim Sistemi** örneğidir. Sistem; sipariş, ürün ve kargo süreçlerini yönetmek için çeşitli aggregate ve domain event’ler kullanmaktadır.

## Proje Yapısı

Sistem, e-ticaret sipariş yönetimi süreçlerini kapsayan üç ana aggregate içermektedir:

- **Order Aggregate**: Siparişleri ve sipariş detaylarını yönetir.
- **Product Aggregate**: Ürün bilgilerini ve stok durumunu yönetir.
- **Cargo Aggregate**: Kargo süreçlerini ve teslimat bilgilerini yönetir.

### Domain Event’leri

Proje, `Domain Events` kullanarak çeşitli olayları yönetir:

- **OrderPlaced**: Bir sipariş oluşturulduğunda tetiklenir.
- **StockChecked**: Ürün stoğu kontrol edildiğinde tetiklenir.
- **OrderShipped**: Sipariş kargoya verildiğinde tetiklenir.

Bu olaylar, sistemin farklı bileşenleri arasında iletişim sağlar ve iş akışını düzenler.

## Veri Tabanı Yapısı

Proje, **EF Core SQL Provider** kullanarak bir SQL veritabanında çalışır. Ana veri tabloları aşağıdaki gibidir:

- **Order**: Sipariş bilgilerini içerir. (Örn: Sipariş Durumu, Toplam Tutar)
- **Product**: Ürün bilgilerini içerir. (Örn: Stok Miktarı, Ürün Tanımı)
- **OrderItem**: Sipariş edilen ürünleri ve miktarlarını içerir.
- **Cargo**: Kargo bilgilerini ve teslimat durumunu içerir.

### Tablo Yapıları

- **Order Tablosu**
  - `OrderID`: Sipariş Kimliği
  - `TotalAmount`: Toplam Tutar
  - `Status`: Sipariş Durumu (Submitted, Canceled)

- **OrderItem Tablosu**
  - `OrderID`: Sipariş Kimliği
  - `ProductID`: Ürün Kimliği
  - `Status`: Sipariş Kalemi Durumu

- **Product Tablosu**
  - `Cost`: Ürün Maliyeti
  - `OrderId`: Sipariş Kimliği
  - `Stock`: Stok Miktarı
  - `Quantity`: Sipariş Miktarı
  - `Desc`: Ürün Açıklaması


## Kurulum

### Gereksinimler

- .NET Core SDK
- SQL Server
- EF Core

![DDDSample](https://github.com/user-attachments/assets/08f02925-c0dc-41e6-a114-09f7d7e6e6f5)
