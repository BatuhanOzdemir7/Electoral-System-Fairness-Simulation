using System;
using System.Text;
using System.Collections.Generic;

namespace AdilMeclisSimulasyonu
{
    // C kodundaki struct yapısının C# karşılığı
    public class LocalizationStrings
    {
        public string[] DistrictNames { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string TotalPopulation { get; set; }
        public string DistrictPopulation { get; set; }
        public string PopulationRatio { get; set; }
        public string AskForReps { get; set; }
        public string InvalidChoice { get; set; }

        // Sistem 1
        public string System1Title { get; set; }
        public string System1Subtitle1 { get; set; }
        public string System1Subtitle2 { get; set; }
        public string SecurityAssign { get; set; }
        public string RepAssigned { get; set; }
        public string CurrentReps { get; set; }

        // Sistem 2
        public string System2Title { get; set; }
        public string System2Subtitle { get; set; }
        public string RepNAssigned { get; set; }

        // Adaletsizlik Hesaplama
        public string JusticeTitle { get; set; }
        public string JusticeRepRepresents { get; set; }
        public string DistrictRepPower { get; set; }
        public string PersonPerRep { get; set; }
        public string DeviationFromAvg { get; set; } // C kodunda kullanılmamış ama struct'ta vardı, burada da tutuyoruz
        public string DistrictNoReps { get; set; }
        public string SystemJusticeScore { get; set; }

        // Karşılaştırma
        public string FinalComparisonTitle { get; set; }
        public string System1Score { get; set; }
        public string System2Score { get; set; }
        public string ResultEqual { get; set; }
        public string ResultSys1Better { get; set; }
        public string ResultSys2Better { get; set; }
    }

    class Program
    {
        // --- TÜRKÇE METİNLER ---
        static LocalizationStrings TR = new LocalizationStrings
        {
            DistrictNames = new string[] { "Merkez", "Çiftlikköy", "Çınarcık", "Altınova", "Armutlu", "Termal" },

            Title = "ADİL BİR MECLİS NASIL SAĞLANIR",
            Subtitle = "Batuhan Hakkaniyet Modeli ile Güncel Kullanımdaki Saf D'Hondt Yönteminin Yalova örneği üzerinde pratikte bir karşılaştırması.",
            TotalPopulation = "Toplam nüfus: \t\t\t{0:F0}\n\n",
            DistrictPopulation = "{0,-11} ilçesinin nüfusu:\t{1:F0}",
            PopulationRatio = "\t(Oranı: % {0:F2})\n",
            AskForReps = "\nToplamda kaç vekil olmasını istiyorsunuz?: ",
            InvalidChoice = "Geçersiz seçim. İngilizce ile devam ediliyor.\n",

            System1Title = "SİSTEM 1: BATUHAN HAKKANİYET MODELİ",
            System1Subtitle1 = "İstediğiniz vekil sayısı: \t{0}\nTaban olarak atanan vekil: \t{1}",
            System1Subtitle2 = "Kalan {0} vekil dağıtılıyor...\n\n",
            SecurityAssign = "(Güvenlik) İlk vekil en yüksek nüfusa atanıyor...\n",
            RepAssigned = "{0} ilçesine +1 vekil verildi",
            CurrentReps = " (Mevcut vekil: {0})\n",

            System2Title = "SİSTEM 2: SAF D'HONDT YÖNTEMİ (TÜRKİYE'DE GÜNCEL UYGULANAN YÖNTEM)",
            System2Subtitle = "Vekiller {0} sayısına ulaşana kadar 0'dan başlayarak tek tek dağıtılıyor:\n\n",
            RepNAssigned = "{0}. vekil {1} ilçesine verildi (Mevcut vekil: {2})\n",

            JusticeTitle = "\n--- SİSTEM {0}: Adalet Puanlaması ---\n",
            JusticeRepRepresents = "İl genelinde bir vekil ortalama kaç kişiyi temsil ediyor? : \t{0:F0}\n",
            DistrictRepPower = "{0,-11} ilçesi Temsil Gücü: \t{1:F0}",
            PersonPerRep = " kişi/vekil \t(Ortalamadan %{0:F2} sapma)\n",
            DistrictNoReps = "{0,-11} ilçesi hiç vekil alamadı.\n",
            SystemJusticeScore = "\nSİSTEM {0} - Genel Adaletsizlik Puanı (Ort. Yüzdesel Sapma): \t% {1:F2}\n",

            FinalComparisonTitle = "NİHAİ KARŞILAŞTIRMA (Düşük Puan Daha Az Sapma = Daha Adil)\n",
            System1Score = "SİSTEM 1 (Batuhan Hakkaniyet Modeli) Adaletsizlik Puanı: \t% {0:F2}\n",
            System2Score = "SİSTEM 2 (Saf D'Hondt) Adaletsizlik Puanı: \t% {0:F2}\n\n",
            ResultEqual = "Sonuç: İki yöntem de eşit derecede adil bir sonuç üretmiştir.\n",
            ResultSys1Better = "Sonuç: Batuhan Hakkaniyet Modeli, bu veri setinde Saf D'Hondt'tan daha adil bir sonuç üretmiştir.\n",
            ResultSys2Better = "Sonuç: Saf D'Hondt Yöntemi, bu veri setinde Batuhan Hakkaniyet Modelinden daha adil bir sonuç üretmiştir.\n"
        };

        // --- İNGİLİZCE METİNLER ---
        static LocalizationStrings EN = new LocalizationStrings
        {
            DistrictNames = new string[] { "Merkez", "Ciftlikkoy", "Cinarcik", "Altinova", "Armutlu", "Termal" },

            Title = "HOW TO ENSURE A FAIR ASSEMBLY",
            Subtitle = "A practical comparison of the Batuhan Equity Model and the currently used pure D'Hondt Method on the Yalova example.",
            TotalPopulation = "Total population: \t\t{0:F0}\n\n",
            DistrictPopulation = "{0,-11} district population:\t{1:F0}",
            PopulationRatio = "\t(Ratio: % {0:F2})\n",
            AskForReps = "\nHow many representatives do you want in total?: ",
            InvalidChoice = "Invalid choice. Defaulting to English.\n",

            System1Title = "SYSTEM 1: BATUHAN EQUITY MODEL",
            System1Subtitle1 = "Requested number of reps: \t{0}\nBase reps assigned: \t\t{1}",
            System1Subtitle2 = "Distributing remaining {0} reps...\n\n",
            SecurityAssign = "(Security) Assigning first rep to the highest population...\n",
            RepAssigned = "+1 rep given to {0} district",
            CurrentReps = " (Current reps: {0})\n",

            System2Title = "SYSTEM 2: PURE D'HONDT METHOD (CURRENTLY USED IN TURKEY)",
            System2Subtitle = "Distributing reps one by one until {0} is reached:\n\n",
            RepNAssigned = "Rep #{0} given to {1} district (Current reps: {2})\n",

            JusticeTitle = "\n--- SYSTEM {0}: Fairness Scoring ---\n",
            JusticeRepRepresents = "On average, how many people does one rep represent province-wide? : \t{0:F0}\n",
            DistrictRepPower = "{0,-11} district Rep. Power: \t{1:F0}",
            PersonPerRep = " people/rep \t(Deviates %{0:F2} from avg)\n",
            DistrictNoReps = "{0,-11} district received no reps.\n",
            SystemJusticeScore = "\nSYSTEM {0} - Overall Unfairness Score (Avg. Pct. Deviation): \t% {1:F2}\n",

            FinalComparisonTitle = "FINAL COMPARISON (Lower Score = Less Deviation = More Fair)\n",
            System1Score = "SYSTEM 1 (Batuhan Equity Model) Unfairness Score: \t% {0:F2}\n",
            System2Score = "SYSTEM 2 (Pure D'Hondt) Unfairness Score: \t% {0:F2}\n\n",
            ResultEqual = "Result: Both methods produced an equally fair outcome.\n",
            ResultSys1Better = "Result: The Batuhan Equity Model produced a fairer outcome than Pure D'Hondt for this dataset.\n",
            ResultSys2Better = "Result: The Pure D'Hondt Method produced a fairer outcome than the Batuhan Equity Model for this dataset.\n"
        };

        // Adaletsizlik Puanını hesaplayan yardımcı fonksiyon
        static float CalculateAdaletsizlikPuani(LocalizationStrings S, float[] nufus, int[] vekil, int vekilSayisi, float toplamNufus, int ilceSayisi, int sistemNo)
        {
            Console.WriteLine(S.JusticeTitle, sistemNo);

            float ilOrtalamasi = toplamNufus / (float)vekilSayisi;
            Console.WriteLine(S.JusticeRepRepresents, ilOrtalamasi);

            float toplamYuzdeselSapma = 0;

            for (int i = 0; i < ilceSayisi; i++)
            {
                if (vekil[i] > 0)
                {
                    float ilceTemsilGucu = nufus[i] / (float)vekil[i];
                    float fark = ilceTemsilGucu - ilOrtalamasi;
                    float yuzdeselSapma = (Math.Abs(fark) / ilOrtalamasi) * 100.0f;

                    Console.Write(S.DistrictRepPower, S.DistrictNames[i], ilceTemsilGucu);
                    Console.Write(S.PersonPerRep, yuzdeselSapma);

                    toplamYuzdeselSapma += yuzdeselSapma;
                }
                else
                {
                    Console.Write(S.DistrictNoReps, S.DistrictNames[i]);
                    toplamYuzdeselSapma += 100.0f; // Ceza puanı
                }
            }

            float ortalamaYuzdeselSapma = toplamYuzdeselSapma / (float)ilceSayisi;
            Console.WriteLine(S.SystemJusticeScore, sistemNo, ortalamaYuzdeselSapma);
            return ortalamaYuzdeselSapma;
        }

        static void Main(string[] args)
        {
            // Türkçe karakterlerin konsolda düzgün görünmesi için
            Console.OutputEncoding = Encoding.UTF8;

            int langChoice;
            LocalizationStrings S;

            // 1. Dil Seçimi
            Console.Write("Lütfen dil seçin / Please select language (1: Türkçe / 2: English): ");
            // C'deki scanf yerine TryParse kullanımı daha güvenlidir ama
            // C kodundaki mantığı birebir korumak için basit okuma yapıyoruz.
            if (!int.TryParse(Console.ReadLine(), out langChoice))
            {
                langChoice = 0; // Hatalı giriş
            }

            // 2. Metin Nesnesini Ayarla
            if (langChoice == 1)
            {
                S = TR;
            }
            else
            {
                S = EN;
                if (langChoice != 2)
                {
                    Console.WriteLine(S.InvalidChoice);
                }
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine(S.Title);
            Console.WriteLine(S.Subtitle);
            Console.WriteLine("------------------------------");

            float[] nufus = { 157499, 56387, 40632, 34090, 11827, 7447 };
            int ilceSayisi = 6;
            float[] yuzde = new float[ilceSayisi];
            float toplam = 0;

            for (int i = 0; i < ilceSayisi; i++)
            {
                toplam += nufus[i];
            }
            Console.WriteLine(S.TotalPopulation, toplam);

            for (int i = 0; i < ilceSayisi; i++)
            {
                yuzde[i] = (nufus[i] / toplam) * 100;
                Console.Write(S.DistrictPopulation, S.DistrictNames[i], nufus[i]);
                Console.Write(S.PopulationRatio, yuzde[i]);
            }

            int teorikTop;
            Console.Write(S.AskForReps);
            if (!int.TryParse(Console.ReadLine(), out teorikTop))
            {
                teorikTop = 0; // Varsayılan veya hata durumu
            }

            // İki sistem için de vekil dizileri
            int[] vekilOrijinal = new int[ilceSayisi];
            int[] vekilDh = new int[ilceSayisi];

            int pratikTopOrijinal = 0;

            //*****************************************************
            // TEMEL ATAMA: Sadece Orijinal Sistem için taban ataması yap
            //*****************************************************
            for (int i = 0; i < ilceSayisi; i++)
            {
                // C kodunda: (teorikTop * (yuzde[i] / 100)) - int cast ile aşağı yuvarlar
                int tabanVekil = (int)(teorikTop * (yuzde[i] / 100.0f));
                vekilOrijinal[i] = tabanVekil;
                pratikTopOrijinal += tabanVekil;
            }

            //*****************************************************
            // SISTEM 1: BATUHAN HAKKANİYET MODELİ (HATA PAYI HER ADIMDA HESAPLANAN)
            //*****************************************************
            Console.WriteLine("\n\n------------------------------");
            Console.WriteLine(S.System1Title);
            Console.WriteLine("------------------------------");
            Console.WriteLine(S.System1Subtitle1, teorikTop, pratikTopOrijinal);
            Console.WriteLine(S.System1Subtitle2, teorikTop - pratikTopOrijinal);

            float[] teorikYuzde = new float[ilceSayisi];
            float[] hataPayi = new float[ilceSayisi];

            while (pratikTopOrijinal < teorikTop)
            {
                int minIndex = 0;

                if (pratikTopOrijinal == 0)
                {
                    // *** SIFIRA BÖLME HATASI DÜZELTMESİ ***
                    Console.Write(S.SecurityAssign);
                    float maxNufus = 0;
                    for (int i = 0; i < ilceSayisi; i++)
                    {
                        if (nufus[i] > maxNufus)
                        {
                            maxNufus = nufus[i];
                            minIndex = i;
                        }
                    }
                }
                else
                {
                    // 1. O anki duruma göre hata paylarını hesapla
                    for (int i = 0; i < ilceSayisi; i++)
                    {
                        teorikYuzde[i] = (float)vekilOrijinal[i] * 100.0f / (float)pratikTopOrijinal;
                        hataPayi[i] = teorikYuzde[i] - yuzde[i]; // Fiili Yüzde - İdeal Yüzde
                    }

                    // 2. En düşük hata payına (en mağdur) sahip ilçeyi bul
                    float minHata = 999.0f; // Yüksek bir değerle başla
                    for (int i = 0; i < ilceSayisi; i++)
                    {
                        if (hataPayi[i] < minHata)
                        {
                            minHata = hataPayi[i];
                            minIndex = i;
                        }
                    }
                }

                // 3. Vekili o ilçeye ata
                vekilOrijinal[minIndex]++;
                pratikTopOrijinal++;
                Console.Write(S.RepAssigned, S.DistrictNames[minIndex]);
                Console.Write(S.CurrentReps, vekilOrijinal[minIndex]);
            }

            // Orijinal sistemin puanını hesapla
            float puanOrijinal = CalculateAdaletsizlikPuani(S, nufus, vekilOrijinal, teorikTop, toplam, ilceSayisi, 1);


            //*****************************************************
            // SISTEM 2: SAF D'HONDT YONTEMI (TURKIYE)
            //*****************************************************
            Console.WriteLine("\n\n------------------------------");
            Console.WriteLine(S.System2Title);
            Console.WriteLine("------------------------------");
            Console.WriteLine(S.System2Subtitle, teorikTop);

            // D'Hondt için vekil sayılarını sıfırla
            for (int i = 0; i < ilceSayisi; i++)
            {
                vekilDh[i] = 0;
            }

            for (int k = 0; k < teorikTop; k++)
            {
                // Toplam vekil sayısı kadar (0'dan başlayarak) dön
                float maxOncelik = 0;
                int maxIndex = 0;

                for (int i = 0; i < ilceSayisi; i++)
                {
                    // D'Hondt Böleni: Nüfus / (Alınan vekil + 1)
                    float oncelikPuani = nufus[i] / (float)(vekilDh[i] + 1);

                    if (oncelikPuani > maxOncelik)
                    {
                        maxOncelik = oncelikPuani;
                        maxIndex = i;
                    }
                }

                // O anki en yüksek puana sahip ilçeye vekili ata
                vekilDh[maxIndex]++;
                Console.Write(S.RepNAssigned, k + 1, S.DistrictNames[maxIndex], vekilDh[maxIndex]);
            }

            // Saf D'Hondt sisteminin puanını hesapla
            float puanDh = CalculateAdaletsizlikPuani(S, nufus, vekilDh, teorikTop, toplam, ilceSayisi, 2);


            //*****************************************************
            // KARSILASTIRMA SONUCU
            //*****************************************************
            Console.WriteLine("\n\n------------------------------");
            Console.Write(S.FinalComparisonTitle);
            Console.WriteLine("------------------------------");

            Console.Write(S.System1Score, puanOrijinal);
            Console.Write(S.System2Score, puanDh);

            if (Math.Abs(puanOrijinal - puanDh) < 0.001)
            {
                Console.Write(S.ResultEqual);
            }
            else if (puanOrijinal < puanDh)
            {
                Console.Write(S.ResultSys1Better);
            }
            else
            {
                Console.Write(S.ResultSys2Better);
            }

            // Konsol hemen kapanmasın diye
            Console.ReadLine();
        }
    }
}
