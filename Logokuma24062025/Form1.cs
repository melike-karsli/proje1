using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; // Newtonsoft.Json kütüphanesi ile JSON verileri işlenebilir. 

namespace Logokuma24062025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DosyalariYukle();
        }


        private void DosyalariYukle()
        {
            string klasorYolu = @"D:\RestoPOS\MY\LOG\";

            if (Directory.Exists(klasorYolu)) //Belirtilen klasör  mevcut mu
            {
                string[] dosyalar = Directory.GetFiles(klasorYolu, "*.txt"); //Eğer klasör varsa, .txt uzantılı tüm dosyalar dosyalar dizisine alınır.

                foreach (string dosyaYolu in dosyalar) //Her bir .txt dosyası için işlem yapılır.
                {
                    string dosyaAdi = Path.GetFileName(dosyaYolu); //Dosyanın tam yolu içinden sadece adı alınır.Örn: Ankara_log1.txt

                    string[] parcalar = dosyaAdi.Split('_'); //Dosya adı _ karakteriyle parçalanır

                    if (parcalar.Length > 0)
                    {
                        string ilkParca = parcalar[0]; //Parçalama sonucu en az bir parça varsa, ilk parça alınır 

                        if (!kaynak_combo.Items.Contains(ilkParca)) //Eğer bu ilk parça ComboBox'ta (yani kaynak_combo) yoksa, listeye eklenir. Böylece her kaynak adı bir kez görünür.
                        {
                            kaynak_combo.Items.Add(ilkParca);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Klasör bulunamadı.");
            }
        }

        string[] satirlar;
        string DosyaTarihi;

        private void kaynak_combo_SelectedIndexChanged(object sender, EventArgs e)    
        {       
            string secilenAd = kaynak_combo.SelectedItem.ToString();  //ComboBox’tan seçilen değeri secilenAd olarak alır.
            string klasorYolu = @"D:\RestoPOS\MY\LOG\";
            string[] dosyalar = Directory.GetFiles(klasorYolu, $"{secilenAd}_*.txt"); //D:\RestoPOS\MY\LOG\ klasöründe, secilenAd_ ile başlayan .txt dosyalarını bulur.

            logyazdır.Clear(); // Önce TextBox'ı temizle

            DosyaTarihi = tarihsec.Value.ToString("yyyyMMdd");

            if (File.Exists(klasorYolu + secilenAd + "_" + DosyaTarihi + ".txt"))
            {
                logyazdır.LoadFile(klasorYolu + secilenAd + "_" + DosyaTarihi + ".txt", RichTextBoxStreamType.PlainText);
            }
            else
            {
                MessageBox.Show("bulunamadı");
            }



        foreach (string dosyaYolu in dosyalar)
        {
            satirlar = File.ReadAllLines(dosyaYolu); //Şu anki dosyaYolu dosyasındaki tüm satırları okur. Her satır bir string olacak şekilde bir dizi (string[] satirlar) oluşur.

        }

        if (dosyalar.Length == 0)
        {
            logyazdır.Text = "Dosya bulunamadı.";
        }


        }

        public string FncIngenicoOdemeTip(string tip)
        {
            if (tip == "1")
                return "NAKIT";
            else if (tip == "4")
                return "BANKAKARTI";
            else if (tip == "8")
                return "YC_YEMEKCEKI";
            else if (tip == "16")
                return "MOBIL";
            else if (tip == "32")
                return "HEDIYE_CEKI";
            else if (tip == "512")
                return "PUAN";
            else if (tip == "2048")
                return "BANKA_TRANSFERI";
            else if (tip == "16384")
                return "DIGER";
            else if (tip == "4503599627370496")
                return "TR_KAREKOD_CARD";
            else if (tip == "18014398509481984")
                return "TR_KAREKOD_MOBIL";
            else if (tip == "36028797018963968")
                return "TR_KAREKOD_DIGER";
            else if (tip == "9007199254740992")
                return "TR_KAREKOD_FAST";
            else
                return ""; // veya "BILINMEYEN TIP"
        }

        public string fnc_IngenicoBankaKod(string tip)
        {
            if (tip == "0")
                return "YC_YEMEKCEKI";
            else if (tip == "46")
                return "AKBANK";
            else if (tip == "64")
                return "ISBANK";
            else if (tip == "62")
                return "GARANTI";
            else if (tip == "67")
                return "YAPIKREDI";
            else if (tip == "12")
                return "HALKBANK";
            else if (tip == "32")
                return "TEB";
            else if (tip == "10")
                return "ZIRAATBANK";
            else if (tip == "134")
                return "DENIZBANK";
            else if (tip == "111")
                return "FINANSBANK";
            else if (tip == "59")
                return "SEKERBANK";
            else if (tip == "15")
                return "VAKIFBANK";
            else if (tip == "124")
                return "ALTERNATIFBANK"; // Not: AKBANK ile çakışıyordu, sonuncusu kaldı
            else if (tip == "143")
                return "AKTIFBANK";
            else if (tip == "203")
                return "ALBARAKA";
            else if (tip == "92")
                return "CITIBANK";
            else if (tip == "71")
                return "FORTISBANK";
            else if (tip == "123")
                return "HSBCBANK";
            else if (tip == "9009")
                return "SEKERSIRKETBANK";
            else if (tip == "206")
                return "TURKIYEFINANSBANK";
            else if (tip == "205")
                return "KUVEYTTURK";
            else if (tip == "17")
                return "TKALKINMABANK";
            else if (tip == "135")
                return "ANADOLUBANK";
            else if (tip == "22970")
                return "YC_TICKET";
            else if (tip == "-12917")
                return "YC_YEMEKCEKI";
            else if (tip == "-12902")
                return "YC_METROPOL";
            else if (tip == "-12923")
                return "YC_MULTINET";
            else if (tip == "22973")
                return "YC_SODEXO";
            else if (tip == "-12882")
                return "YC_PAYE";
            else if (tip == "-12887")
                return "YC_SETCARD";
            else if (tip == "-12875")
                return "PAYCELLQR";
            else if (tip == "8083")
                return "ODEAL";
            else if (tip == "52657")
                return "TELIUM";
            else
                return "ODEME";
        }

        string fnc_IngenicoOdemeTip(string paymentTypeEx)  // PaymentTypeEx'e göre ödeme açıklaması döndürür.
        {
            if (paymentTypeEx == "1")
                return "Nakit";
            else if (paymentTypeEx == "512")
                return "Puan";
            else if (paymentTypeEx == "2048")
                return "Banka Transferi";
            else
                return "Diğer";
        }


        //string fnc_IngenicoBankaKod(string bankBKMID)  // Banka koduna göre açıklama döndürür.
        //{
        //    if (bankBKMID == "46")
        //        return "AKBANK";
        //    else if (bankBKMID == "64")
        //        return "İŞBANK";
        //    else if (bankBKMID == "62")
        //        return "GARANTİ";
        //    else if (bankBKMID == "0")
        //        return "YEMEKÇEKİ";
        //    else
        //        return "Bilinmeyen Banka";
        //}

        //TSM
        private void LogTSM(string json)
        {


            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("AdisyonNo", "Adisyon No");
                dataGridView1.Columns.Add("SerialNo", "Serial No");
                dataGridView1.Columns.Add("EkuNo", "EKU No");
                dataGridView1.Columns.Add("ZNo", "Z No");
                dataGridView1.Columns.Add("ReceiptNo", "Receipt No");
                dataGridView1.Columns.Add("TransDateTime", "Tarih");
                dataGridView1.Columns.Add("PaymentTypeEx" + ":" + "PaymentAmount", "Odeme Bilgisi");
            }

            try
            {
                logokuclass.IngenicoData veri = JsonConvert.DeserializeObject<logokuclass.IngenicoData>(json);

                // Veriyi DataGridView'e ekle

                // Örnek: PaymentList içindeki tüm öğeleri yazdırma


                //string odemeler = "";
                string odemetipi = "";
                string banka = ""; // Banka kodunu tutacak değişken 
                string odemeText = ""; // Ödeme bilgilerini tutacak string

                if (veri?.Receipt?.PaymentList != null) //veri null değilse, Receipt null değilse,PaymentList null değilse, o zaman if bloğuna giriyor.

                {

                    for (int i = 0; i < veri.Receipt.PaymentList.Count; i++)  //PaymentList içinde kaç ödeme varsa (Count kadar), her birini i indeksiyle teker teker geziyor.
                                                                              //  Yani örnek olarak:PaymentList[0] → 1.ödeme PaymentList[1] → 2.ödeme
                    {
      
                        odemetipi = veri.Receipt?.PaymentList[i].PaymentTypeEx.ToString()?? ""; // PaymentTypeEx değerini kullanarak ödeme tipini alır
                        
                        banka = veri.Receipt?.PaymentList[i].BankBKMID.ToString()??""; // Banka kodunu alır

                        // Merchantid artık object olduğu için güvenli şekilde stringe çeviriyoruz
                        string merchantId = veri.Receipt.PaymentList[i].Merchantid?.ToString() ?? "";

                        if (odemetipi == "1" || odemetipi == "512" || odemetipi == "2048")
                            odemeText += fnc_IngenicoOdemeTip(odemetipi);
                        else
                            odemeText += fnc_IngenicoBankaKod(banka);

                        odemeText += ":" + ((veri.Receipt?.PaymentList?[i]?.PaymentAmount ?? 0) / 100) + "$"; //PaymentAmount genelde kuruş cinsinden geldiği için /100 yapılıyor → TL’ye çevrilir. Null ise 0 alınır.  Sonuç "OdemeTipi:Banka:50$" gibi bir metne dönüşür.

                    }
                    odemeText = odemeText.TrimEnd('$'); // Sonundaki $ işaretini kaldırır

                    dataGridView1.Rows.Add

                    (
                        veri.AdisyonNo.ToString() ?? "",
                        veri.SerialNo.Trim(),
                        veri.Receipt.EkuNo,
                        veri.Receipt.ZNo,
                        veri.Receipt.ReceiptNo,
                        veri.Receipt.TransDateTime,
                        odemeText


                     );

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JSON işleme hatası: " + ex.Message);
            }
        }

        //TRENDYOL
        private void RestoSepetTrendyol(string json)
        {
            if (datagridrestosepet.Columns.Count == 0)
            {
                datagridrestosepet.Rows.Clear();
                datagridrestosepet.Columns.Clear();
                datagridrestosepet.Columns.Add("kanal", "Satış kanalı");
                datagridrestosepet.Columns.Add("id", "Sipariş No");
                datagridrestosepet.Columns.Add("totalPrice", "Toplam Tutar");
                datagridrestosepet.Columns.Add("totalSellerAmount", "Toplam İndirim");
                datagridrestosepet.Columns.Add("callCenterPhone", "İletişim No");
                datagridrestosepet.Columns.Add("Name", "Müşteri");              
                datagridrestosepet.Columns.Add("paymentType", "Ödeme Tipi");
             //   datagridrestosepet.Columns.Add("address", "Adres");
                datagridrestosepet.Columns.Add("name", "Ana Ürün");
                datagridrestosepet.Columns.Add("modifierNamesStr", "İçindekiler");
            }

            var veri1 = JsonConvert.DeserializeObject<logokurestosepetclass.trendyollog>(json); //json isimli stringi, sizin tanımladığınız trendyollog class’ına çeviriyor.

            if (veri1?.content == null) return; //Eğer veri1 boşsa veya content listesi yoksa, fonksiyon duruyor.


            foreach (var contentItem in veri1.content) //JSON içindeki content listesi üzerinde tek tek dönüyor.
            {
                var lines = contentItem?.lines ??  new List<logokurestosepetclass.lines>();  //Her contentItem'ın lines adlı bir listesi var.
                 //Eğer lines null ise boş bir liste (new List<...>()) oluşturuyor.
                //Böylece lines null olsa da foreach patlamıyor.
                
                foreach (var line in lines)
                {
                    // Modifier ürünler
                    var modifierNames = line?.modifierProducts? //line değişkenin varsa (null değilse) → onun içindeki modifierProducts listesini al.
                                            .Select(m => m?.name ?? "") //modifierProducts listesindeki her bir m için:Eğer m null değilse → m.name al.Eğer m ya da m.name null ise → boş string "" döndür.
                                            .ToList() ?? new List<string>(); // .ToList() ?? new List<string>()Select sonucu bir listeye(List<string>) çevriliyor.Eğer yukarıdaki işlemlerin tamamı null dönerse, boş bir liste(new List<string>()) oluştur.

                    string modifierNamesStr = string.Join(", ", modifierNames); //string modifierNamesStr = string.Join(", ", modifierNames); Listeyi alıp string’e çeviriyorsun.Örn: ["Peynir", "Zeytin", "Domates"] → "Peynir, Zeytin, Domates".Eğer liste boşsa → sonuç ""(boş string) olur.

                    // Promotions toplam
                    string totalSellerAmount = contentItem?.promotions?.FirstOrDefault()?.totalSellerAmount.ToString() ?? "0";



                    // aynı sipariş varsa ekleme

                    bool zatenVar = datagridrestosepet.Rows
                  .Cast<DataGridViewRow>()
                  .Any(r => r.Cells["id"].Value?.ToString() == contentItem.id.ToString());

                    if (zatenVar) continue; 




                    // Satırı DataGridView'e ekle
                    datagridrestosepet.Rows.Add(


                        "Trendyol",  // Sabit değer

                        contentItem?.id ?? "",

                        (contentItem?.totalPrice != null ? contentItem.totalPrice.ToString("F0") : "0"),

                        totalSellerAmount,

                        contentItem?.callCenterPhone ?? "",

                        $"{contentItem?.customer?.firstName ?? ""} {contentItem?.customer?.lastName ?? ""} ",
                        
                        contentItem?.payment?.paymentType ?? "",

                     //   $"{contentItem?.address?.city ?? ""}/{contentItem?.address?.district ?? ""}/{contentItem?.address?.neighborhood ?? ""}",

                        line?.name ?? "",

                        modifierNamesStr
                    );
                }
            }
        }


        //GETIR
        private void Restosepetgetir(string json)
        {
            if (datagridrestosepet.Columns.Count == 0)
            {
                datagridrestosepet.Rows.Clear();
                datagridrestosepet.Columns.Clear();
                datagridrestosepet.Columns.Add("kanal", "Satış kanalı");
                datagridrestosepet.Columns.Add("id", "Sipariş No");
                datagridrestosepet.Columns.Add("name", "Musteriadı");
                datagridrestosepet.Columns.Add("clientPhoneNumber", "İletişim No");
                datagridrestosepet.Columns.Add("product", "Urunler");
                datagridrestosepet.Columns.Add("totalPrice", "toplamtutar");

            }
            var veri2 = JsonConvert.DeserializeObject<getir.getirlog>(json);

            // Eğer products null ise çık
            if (veri2?.products == null) return;

            // JSON içindeki products listesi üzerinde dön
            foreach (var product in veri2.products)
            {
                // Modifier ürünler (optionCategories içindeki options isimleri)
                var modifierNames = product.optionCategories?
                                        .SelectMany(oc => oc.options)
                                        .Select(o => o.name?.tr ?? "")
                                        .ToList() ?? new List<string>();

                string modifierNamesStr = string.Join(", ", modifierNames);

               
                // Satırı DataGridView'e ekle
                datagridrestosepet.Rows.Add(

                    "Getir",  // Sabit değer
                    veri2.id ?? "",                          // sipariş id

                   // (veri2?.products.totalPrice != null ? veri2.products.totalPrice.ToString("F0") : "0"),
                   // veri2.products.totalPrice,
                   veri2.products.FirstOrDefault()?.totalPrice, // toplam fiyat

                    product.optionCategories?
                           .SelectMany(oc => oc.options)
                           .Sum(o => o.price)                // toplam indirim
                           .ToString("F0") ?? "0",

                    veri2.client?.clientPhoneNumber ?? "", // veri2.client?.location?.FirstOrDefault()?.clientPhoneNumber ?? "",List olmadıgı ıcın boyle yazılmaz

                    veri2.client?.name ?? "",                // müşteri adı

                    veri2.paymentMethodText?.tr ?? "",                   

                //    $"{veri2.client?.location?.lat ?? ""}/{ veri2.client?.location?.lon ?? "" }", // adres

                    product.name?.tr ?? "",                  // ürün adı (TR)
                    
                    modifierNamesStr                         // opsiyonlar
                );
            }

        }



        //YEMEKSEPETİ
        private void Restosepetyemeksepeti(string json)
        {
            if (datagridrestosepet.Columns.Count == 0)
            {
                datagridrestosepet.Rows.Clear();
                datagridrestosepet.Columns.Clear();

                datagridrestosepet.Columns.Add("kanal", "Satış kanalı");
                datagridrestosepet.Columns.Add("code", "Sipariş Kodu");
                datagridrestosepet.Columns.Add("grandTotal", "Toplam Tutar");
                datagridrestosepet.Columns.Add("discounts", "Toplam indirim");
                datagridrestosepet.Columns.Add("mobilePhone", "Müşteri Telefon");
                datagridrestosepet.Columns.Add("firstname", "Müşteri Adı");
                datagridrestosepet.Columns.Add("paymentType", "Ödeme Tipi");
                datagridrestosepet.Columns.Add("createdAt", "Oluşturulma Tarihi");
                datagridrestosepet.Columns.Add("platform", "Platform");    
                datagridrestosepet.Columns.Add("products", "Ürünler");
               
            }
            var veri3 = JsonConvert.DeserializeObject<yemeksepeti.yemeksepetilog>(json);
            if (veri3?.products == null) return;

            foreach (var product in veri3.products)
            {
                // Ürün bilgilerini birleştir
               
                string urunBilgisi = string.Join(", ",
                veri3.products.Select(p => $"{p.name} (Adet: {p.quantity})"));

                string toppings = product.selectedToppings != null
                 ? string.Join(", ", product.selectedToppings.Select(t => t.name)) //Select(t => t.name) → sadece adlarını alır string.Join(", ", ...) → virgülle birleştirir
                 : "";

                string adres = veri3.delivery?.address != null
                ? $"{veri3.delivery.address.city ?? ""} {veri3.delivery.address.deliveryMainArea ?? ""} {veri3.delivery.address.street ?? ""} {veri3.delivery.address.number ?? ""}"
                   : "";



                // Satırı DataGridView'e ekle
                datagridrestosepet.Rows.Add(

                    "Yemeksepeti",  // Sabit değer

                    veri3.platformRestaurant.id ?? "",

                    veri3.price?.grandTotal ?? "",

                    veri3.discounts.Count.ToString(), // Toplam indirim sayısı

                    veri3.customer?.mobilePhone ?? "",

                    $"{veri3.customer?.firstname ?? ""} {veri3.customer?.lastname ?? ""}",

                    veri3.payment?.type ?? "",

                   // adres,
                    
                    urunBilgisi,

                    toppings



                );
            }
        }


        //MİGROS
        private void Restosepetmigros(string json)
        {
            if (datagridrestosepet.Columns.Count == 0)
            {
                datagridrestosepet.Rows.Clear();
                datagridrestosepet.Columns.Clear();

                datagridrestosepet.Columns.Add("kanal", "Satış kanalı");
                datagridrestosepet.Columns.Add("id", "Sipariş No");
                datagridrestosepet.Columns.Add("totalPrice", "Toplam Tutar");
                datagridrestosepet.Columns.Add("discountedPrice", "Toplam İndirim");
                datagridrestosepet.Columns.Add("phoneNumber", "İletişim No");
                datagridrestosepet.Columns.Add("customerFullName", "Müşteri");
                datagridrestosepet.Columns.Add("paymentType", "Ödeme Tipi");
               // datagridrestosepet.Columns.Add("address", "Adres");
                datagridrestosepet.Columns.Add("name", "Ana Ürün");
                datagridrestosepet.Columns.Add("options", "İçindekiler");
            }

            var veri4 = JsonConvert.DeserializeObject<migros.migroslog>(json);

            if (veri4?.data == null) return;

            // data içinde dön
            foreach (var store in veri4.data)
            {
                // pendingOrderDetailsDTOS içinde dön
                foreach (var order in store.pendingOrderDetailsDTOS)
                {
                    if (order.products == null) continue;

                   
                    string urunbilgisi = string.Join(", ",

                        order.products.Select(p =>
                        p.options != null && p.options.Any()
                            ? string.Join("; ", p.options.Select(o => o.itemNames))
                            : ""
                        )

                    );


                    foreach (var product in order.products)
                    {
                        datagridrestosepet.Rows.Add
                        (
                            "Migros",  // Sabit değer

                            order.id,

                            order.totalPrice,

                            order.primaryDiscountedPriceText,

                            order.phoneNumber,

                            order.customerFullName,

                            order.paymentType,

                            //order.address,

                            product?.name ?? "",

                            urunbilgisi
                        );
                    }
                }
            }
        }

        




        // Form seviyesinde (class içine yazılacak)
        private HashSet<string> islenmisJsonlar = new HashSet<string>();

        public void button1_Click_1(object sender, EventArgs e)
        {


            // DataGridView ayarları
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //datagridrestosepet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //datagridrestosepet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            // Önce DataGridView temizle
            dataGridView1.Rows.Clear();
            datagridrestosepet.Rows.Clear();
            
            

            string klasorYolu = @"D:\RestoPOS\MY\LOG\";
            string secilen = kaynak_combo.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilen))
            {
                MessageBox.Show("Lütfen bir kaynak seçin.");
                return;
            }

            // DateTimePicker’dan seçilen tarihi al
            string dosyaTarihi = tarihsec.Value.ToString("yyyyMMdd");


            // Dosya yolunu oluştur(örn: Yemeksepeti_20250925.txt)
            string dosyaYolu = Path.Combine(klasorYolu, $"{secilen}_{dosyaTarihi}.txt");

            if (!File.Exists(dosyaYolu))
            {
                MessageBox.Show("Seçilen tarihe ait log bulunamadı.");
                return;
            }

            // Dosyayı satır satır oku
            
            string[] satirlar = File.ReadAllLines(dosyaYolu, Encoding.GetEncoding("windows-1254"));



            foreach (string satir in satirlar)
            {
                int jsonStart = satir.IndexOf('{');
                int jsonEnd = satir.LastIndexOf('}');

                if (jsonStart >= 0 && jsonEnd > jsonStart)
                {
                    string json = satir.Substring(jsonStart, jsonEnd - jsonStart + 1);



                    HashSet<string> uniqueIds = new HashSet<string>(); //HashSet, aynı değeri birden fazla saklamaz.

                    // sondan başa doğru dönmek lazım (Sondan başa dönmek, silme sırasında index kaymasını önlüyor.)
                    for (int i = datagridrestosepet.Rows.Count - 1; i >= 0; i--)
                    {
                        var row = datagridrestosepet.Rows[i];
                        var idValue = row.Cells["id"].Value?.ToString(); //Her satırdaki "id" hücresini aldık:

                        if (string.IsNullOrEmpty(idValue)) continue;

                        if (uniqueIds.Contains(idValue)) //Eğer bu id daha önce HashSet’te varsa → satırı sildik.
                        {
                            datagridrestosepet.Rows.RemoveAt(i); // duplicate sil
                        }
                        else
                        {
                            uniqueIds.Add(idValue); // ilk defa gördüysek listeye ekle
                        }
                    }

                    
 


                // Burada hangi sisteme ait olduğunu kontrol et
                if (satir.Contains("Ingenico"))
                        LogTSM(json);

                    else if (satir.Contains("supplierId") && satir.Contains("storeId"))
                        RestoSepetTrendyol(json);

                    else if (satir.Contains("\"confirmationId\""))
                        Restosepetgetir(json);

                    else if (satir.Contains("\"localInfo\"") && satir.Contains("\"expiryDate\""))
                        Restosepetyemeksepeti(json);

                    else if (satir.Contains("\"customerFullName\""))
                        Restosepetmigros(json);
                }
            }
        }

       
    }
}
