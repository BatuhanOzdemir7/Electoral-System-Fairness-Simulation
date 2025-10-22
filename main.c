#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <locale.h> // <- Türkçe karakterler ve yerel ayarlar için eklendi

/*
 * TÜRKÇE KARAKTER NOTU:
 * Kod dosyasýný UTF-8 olarak kaydedin.
 * Windows'ta konsolda düzgün görmek için programý çalýþtýrmadan önce
 * komut satýrýna "chcp 65001" yazmanýz gerekebilir.
*/


// Tüm metinleri tutacak yapý (struct)
struct Strings {
    // Ýlçe Adlarý (Verinin bir parçasý)
    char* districtNames[6];

    // Genel
    char* title;
    char* subtitle;
    char* totalPopulation;
    char* districtPopulation;
    char* populationRatio;
    char* askForReps;
    char* invalidChoice;

    // Sistem 1 (Batuhan Modeli)
    char* system1Title;
    char* system1Subtitle1;
    char* system1Subtitle2;
    char* securityAssign;
    char* repAssigned;
    char* currentReps;

    // Sistem 2 (D'Hondt)
    char* system2Title;
    char* system2Subtitle;
    char* repNAssigned;

    // Adaletsizlik Hesaplama Fonksiyonu
    char* justiceTitle;
    char* justiceRepRepresents;
    char* districtRepPower;
    char* personPerRep;
    char* deviationFromAvg;
    char* districtNoReps;
    char* systemJusticeScore;

    // Nihai Karþýlaþtýrma
    char* finalComparisonTitle;
    char* system1Score;
    char* system2Score;
    char* resultEqual;
    char* resultSys1Better;
    char* resultSys2Better;
};

// --- TÜRKÇE METÝNLER ---
// Not: Türkçe karakterler düzeltildi (Ç, ý, þ, ð)
struct Strings TR = {
    .districtNames = {"Merkez", "Çiftlikköy", "Çýnarcýk", "Altýnova", "Armutlu", "Termal"},

    .title = "ADÝL BÝR MECLÝS NASIL SAÐLANIR",
    .subtitle = "Batuhan Hakkaniyet Modeli ile Güncel Kullanýmdaki Saf D'Hondt Yönteminin Yalova örneði üzerinde pratikte bir karþýlaþtýrmasý.",
    .totalPopulation = "Toplam nüfus: \t\t\t%.0f\n\n",
    .districtPopulation = "%-11s ilçesinin nüfusu:\t%.0f",
    .populationRatio = "\t(Oraný: %% %.2f)\n",
    .askForReps = "\nToplamda kaç vekil olmasýný istiyorsunuz?: ",
    .invalidChoice = "Geçersiz seçim. Ýngilizce ile devam ediliyor.\n",

    .system1Title = "SÝSTEM 1: BATUHAN HAKKANÝYET MODELÝ",
    .system1Subtitle1 = "Ýstediðiniz vekil sayýsý: \t%d\nTaban olarak atanan vekil: \t%d",
    .system1Subtitle2 = "Kalan %d vekil daðýtýlýyor...\n\n",
    .securityAssign = "(Güvenlik) Ýlk vekil en yüksek nüfusa atanýyor...\n",
    .repAssigned = "%s ilçesine +1 vekil verildi",
    .currentReps = " (Mevcut vekil: %d)\n",

    .system2Title = "SÝSTEM 2: SAF D'HONDT YÖNTEMÝ (TÜRKÝYE'DE GÜNCEL UYGULANAN YÖNTEM)",
    .system2Subtitle = "Vekiller %d sayýsýna ulaþana kadar 0'dan baþlayarak tek tek daðýtýlýyor:\n\n",
    .repNAssigned = "%d. vekil %s ilçesine verildi (Mevcut vekil: %d)\n",

    .justiceTitle = "\n--- SÝSTEM %d: Adalet Puanlamasý ---\n",
    .justiceRepRepresents = "Ýl genelinde bir vekil ortalama kaç kiþiyi temsil ediyor? : \t%.0f\n",
    .districtRepPower = "%-11s ilçesi Temsil Gücü: \t%.0f",
    .personPerRep = " kiþi/vekil \t(Ortalamadan %%%.2f sapma)\n",
    .districtNoReps = "%-11s ilçesi hiç vekil alamadý.\n",
    .systemJusticeScore = "\nSÝSTEM %d - Genel Adaletsizlik Puaný (Ort. Yüzdesel Sapma): \t%% %.2f\n",

    .finalComparisonTitle = "NÝHAÝ KARÞILAÞTIRMA (Düþük Puan Daha Az Sapma = Daha Adil)\n",
    .system1Score = "SÝSTEM 1 (Batuhan Hakkaniyet Modeli) Adaletsizlik Puaný: \t%% %.2f\n",
    .system2Score = "SÝSTEM 2 (Saf D'Hondt) Adaletsizlik Puaný: \t%% %.2f\n\n",
    .resultEqual = "Sonuç: Ýki yöntem de eþit derecede adil bir sonuç üretmiþtir.\n",
    .resultSys1Better = "Sonuç: Batuhan Hakkaniyet Modeli, bu veri setinde Saf D'Hondt'tan daha adil bir sonuç üretmiþtir.\n",
    .resultSys2Better = "Sonuç: Saf D'Hondt Yöntemi, bu veri setinde Batuhan Hakkaniyet Modelinden daha adil bir sonuç üretmiþtir.\n"
};

// --- ÝNGÝLÝZCE METÝNLER ---
struct Strings EN = {
    .districtNames = {"Merkez", "Ciftlikkoy", "Cinarcik", "Altinova", "Armutlu", "Termal"},

    .title = "HOW TO ENSURE A FAIR ASSEMBLY",
    .subtitle = "A practical comparison of the Batuhan Equity Model and the currently used pure D'Hondt Method on the Yalova example.",
    .totalPopulation = "Total population: \t\t%.0f\n\n",
    .districtPopulation = "%-11s district population:\t%.0f",
    .populationRatio = "\t(Ratio: %% %.2f)\n",
    .askForReps = "\nHow many representatives do you want in total?: ",
    .invalidChoice = "Invalid choice. Defaulting to English.\n",

    .system1Title = "SYSTEM 1: BATUHAN EQUITY MODEL",
    .system1Subtitle1 = "Requested number of reps: \t%d\nBase reps assigned: \t\t%d",
    .system1Subtitle2 = "Distributing remaining %d reps...\n\n",
    .securityAssign = "(Security) Assigning first rep to the highest population...\n",
    .repAssigned = "+1 rep given to %s district",
    .currentReps = " (Current reps: %d)\n",

    .system2Title = "SYSTEM 2: PURE D'HONDT METHOD (CURRENTLY USED IN TURKEY)",
    .system2Subtitle = "Distributing reps one by one until %d is reached:\n\n",
    .repNAssigned = "Rep #%d given to %s district (Current reps: %d)\n",

    .justiceTitle = "\n--- SYSTEM %d: Fairness Scoring ---\n",
    .justiceRepRepresents = "On average, how many people does one rep represent province-wide? : \t%.0f\n",
    .districtRepPower = "%-11s district Rep. Power: \t%.0f",
    .personPerRep = " people/rep \t(Deviates %%%.2f from avg)\n",
    .districtNoReps = "%-11s district received no reps.\n",
    .systemJusticeScore = "\nSYSTEM %d - Overall Unfairness Score (Avg. Pct. Deviation): \t%% %.2f\n",

    .finalComparisonTitle = "FINAL COMPARISON (Lower Score = Less Deviation = More Fair)\n",
    .system1Score = "SYSTEM 1 (Batuhan Equity Model) Unfairness Score: \t%% %.2f\n",
    .system2Score = "SYSTEM 2 (Pure D'Hondt) Unfairness Score: \t%% %.2f\n\n",
    .resultEqual = "Result: Both methods produced an equally fair outcome.\n",
    .resultSys1Better = "Result: The Batuhan Equity Model produced a fairer outcome than Pure D'Hondt for this dataset.\n",
    .resultSys2Better = "Result: The Pure D'Hondt Method produced a fairer outcome than the Batuhan Equity Model for this dataset.\n"
};


// Adaletsizlik Puanýný hesaplayan yardýmcý fonksiyon
float calculate_adaletsizlik_puani(struct Strings* S, float nufus[], int vekil[], int vekilSayisi, float toplamNufus, int ilceSayisi, int sistemNo) {

    printf(S->justiceTitle, sistemNo);

    float ilOrtalamasi = toplamNufus / (float)vekilSayisi;
    printf(S->justiceRepRepresents, ilOrtalamasi);

    float toplamYuzdeselSapma = 0;
    int i;
    for(i=0; i<ilceSayisi; i++){
        if (vekil[i] > 0) {
            float ilceTemsilGucu = nufus[i] / (float)vekil[i];
            float fark = ilceTemsilGucu - ilOrtalamasi;
            float yuzdeselSapma = (fabs(fark) / ilOrtalamasi) * 100.0;

            printf(S->districtRepPower, S->districtNames[i], ilceTemsilGucu);
            printf(S->personPerRep, yuzdeselSapma);

            toplamYuzdeselSapma += yuzdeselSapma;
        } else {
            printf(S->districtNoReps, S->districtNames[i]);
            toplamYuzdeselSapma += 100.0; // Ceza puaný
        }
    }

    float ortalamaYuzdeselSapma = toplamYuzdeselSapma / (float)ilceSayisi;
    printf(S->systemJusticeScore, sistemNo, ortalamaYuzdeselSapma);
    return ortalamaYuzdeselSapma;
}


int main()
{
    setlocale(LC_ALL, "");

    int langChoice;
    struct Strings* S;

    // 1. Dil Seçimi
    printf("Lütfen dil seçin / Please select language (1: Türkçe / 2: English): ");
    scanf("%d", &langChoice);

    // 2. Metin Ýþaretçisini Ayarla
    if (langChoice == 1) {
        S = &TR;
    } else {
        S = &EN;
        if (langChoice != 2) {
            printf(S->invalidChoice);
        }
    }


    printf("------------------------------\n");
    printf("%s\n", S->title);
    printf("%s\n", S->subtitle);
    printf("------------------------------\n");

    float nufus[] = {157499, 56387, 40632, 34090, 11827, 7447};
    int ilceSayisi = 6;
    float yuzde[ilceSayisi];
    float toplam = 0;
    int i;

    for(i=0; i<ilceSayisi; i++){
        toplam += nufus[i];
    }
    printf(S->totalPopulation, toplam);

    for(i=0; i<ilceSayisi; i++){
        yuzde[i] = (nufus[i] / toplam) * 100;
        printf(S->districtPopulation, S->districtNames[i], nufus[i] );
        printf(S->populationRatio, yuzde[i] );
    }

    int teorikTop;
    printf("%s", S->askForReps);
    scanf("%d", &teorikTop);

    // Ýki sistem için de vekil dizileri
    int vekilOrijinal[ilceSayisi];
    int vekilDh[ilceSayisi];

    int pratikTopOrijinal = 0;

    //*****************************************************
    // TEMEL ATAMA: Sadece Orijinal Sistem için taban atamasý yap
    //*****************************************************
    for(i=0; i<ilceSayisi; i++){
        int tabanVekil = teorikTop * (yuzde[i] / 100);
        vekilOrijinal[i] = tabanVekil;
        pratikTopOrijinal += tabanVekil;
    }


    //*****************************************************
    // SISTEM 1: BATUHAN HAKKANÝYET MODELÝ (HATA PAYI HER ADIMDA HESAPLANAN)
    //*****************************************************
    printf("\n\n------------------------------\n");
    printf("%s\n", S->system1Title);
    printf("------------------------------\n");
    printf(S->system1Subtitle1, teorikTop, pratikTopOrijinal);
    printf(S->system1Subtitle2, teorikTop - pratikTopOrijinal);

    float teorikYuzde[ilceSayisi], hataPayi[ilceSayisi];

    while(pratikTopOrijinal < teorikTop){

        int minIndex = 0;

        if (pratikTopOrijinal == 0) {
            // *** SIFIRA BOLME HATASI DUZELTMESI ***
            printf("%s", S->securityAssign);
            float maxNufus = 0;
            for(i=0; i<ilceSayisi; i++) {
                if(nufus[i] > maxNufus) {
                    maxNufus = nufus[i];
                    minIndex = i;
                }
            }
        } else {
            // Sizin normal hata payý hesaplamanýz
            // 1. O anki duruma göre hata paylarýný hesapla
            for(i=0; i<ilceSayisi; i++){
                teorikYuzde[i] = (float)vekilOrijinal[i] * 100.0 / (float)pratikTopOrijinal;
                hataPayi[i] = teorikYuzde[i] - yuzde[i]; // Fiili Yüzde - Ýdeal Yüzde
            }

            // 2. En düþük hata payýna (en maðdur) sahip ilçeyi bul
            float minHata = 999.0; // Yüksek bir deðerle baþla
            for(i=0; i<ilceSayisi; i++){
                if(hataPayi[i] < minHata){
                    minHata = hataPayi[i];
                    minIndex = i;
                }
            }
        }

        // 3. Vekili o ilçeye ata
        vekilOrijinal[minIndex]++;
        pratikTopOrijinal++;
        printf(S->repAssigned, S->districtNames[minIndex]); // Ýlçe adý S'den geliyor
        printf(S->currentReps, vekilOrijinal[minIndex]);
    }
    // Orijinal sistemin puanýný hesapla (S parametresi eklendi)
    float puanOrijinal = calculate_adaletsizlik_puani(S, nufus, vekilOrijinal, teorikTop, toplam, ilceSayisi, 1);


    //*****************************************************
    // SISTEM 2: SAF D'HONDT YONTEMI (TURKIYE)
    //*****************************************************
    printf("\n\n------------------------------\n");
    printf("%s\n", S->system2Title);
    printf("------------------------------\n");
    printf(S->system2Subtitle, teorikTop);

    // D'Hondt için vekil sayýlarýný sýfýrla
    for(i=0; i<ilceSayisi; i++){
        vekilDh[i] = 0;
    }

    int k;
    for(k=0; k < teorikTop; k++){ // Toplam vekil sayýsý kadar (0'dan baþlayarak) dön

        float maxOncelik = 0;
        int maxIndex = 0;

        for(i=0; i<ilceSayisi; i++){
            // D'Hondt Böleni: Nüfus / (Alýnan vekil + 1)
            float oncelikPuani = nufus[i] / (float)(vekilDh[i] + 1);

            if(oncelikPuani > maxOncelik){
                maxOncelik = oncelikPuani;
                maxIndex = i;
            }
        }

        // O anki en yüksek puana sahip ilçeye vekili ata
        vekilDh[maxIndex]++;
        printf(S->repNAssigned, k+1, S->districtNames[maxIndex], vekilDh[maxIndex]); // Ýlçe adý S'den geliyor
    }
    // Saf D'Hondt sisteminin puanýný hesapla (S parametresi eklendi)
    float puanDh = calculate_adaletsizlik_puani(S, nufus, vekilDh, teorikTop, toplam, ilceSayisi, 2);


    //*****************************************************
    // KARSILASTIRMA SONUCU
    //*****************************************************
    printf("\n\n------------------------------\n");
    printf("%s", S->finalComparisonTitle);
    printf("------------------------------\n");

    printf(S->system1Score, puanOrijinal);
    printf(S->system2Score, puanDh);

    if (fabs(puanOrijinal - puanDh) < 0.001) {
         printf("%s", S->resultEqual);
    } else if (puanOrijinal < puanDh) {
         printf("%s", S->resultSys1Better);
    } else {
         printf("%s", S->resultSys2Better);
    }

    return 0;
}
