import matplotlib.pyplot as plt

# --- VERİ SETİ (YALOVA) ---
DISTRICTS = ["Merkez", "Çiftlikköy", "Çınarcık", "Altınova", "Armutlu", "Termal"]
POPULATIONS = [157499, 56387, 40632, 34090, 11827, 7447]
TOTAL_POP = sum(POPULATIONS)

# --- ADALETSİZLİK PUANI HESAPLAMA ---
def calculate_unfairness(seats, total_seats):
    """
    Hedef: Düşük Puan = Yüksek Adalet
    """
    ideal_ratio = TOTAL_POP / total_seats
    total_deviation = 0
    
    for i in range(len(DISTRICTS)):
        if seats[i] > 0:
            rep_power = POPULATIONS[i] / seats[i]
            deviation = abs(rep_power - ideal_ratio) / ideal_ratio * 100.0
            total_deviation += deviation
        else:
            # Temsil edilmeme cezası
            total_deviation += 100.0 
            
    return total_deviation / len(DISTRICTS)

# --- SİSTEM 1: YİNELEMELİ HAKKANİYET MODELİ ---
def run_iterative_model(total_seats):
    seats = [0] * len(DISTRICTS)
    
    # 1. Taban Atama
    current_assigned = 0
    for i in range(len(DISTRICTS)):
        base_seats = int(total_seats * (POPULATIONS[i] / TOTAL_POP))
        seats[i] = base_seats
        current_assigned += base_seats
        
    # 2. İteratif Hata Dağıtımı
    while current_assigned < total_seats:
        max_victim_score = -float('inf')
        victim_index = -1
        
        if current_assigned == 0:
            victim_index = POPULATIONS.index(max(POPULATIONS))
        else:
            for i in range(len(DISTRICTS)):
                ideal_share = (POPULATIONS[i] / TOTAL_POP) * 100
                current_share = (seats[i] / current_assigned) * 100 if current_assigned > 0 else 0
                victim_score = ideal_share - current_share
                
                if victim_score > max_victim_score:
                    max_victim_score = victim_score
                    victim_index = i
        
        seats[victim_index] += 1
        current_assigned += 1
        
    return calculate_unfairness(seats, total_seats)

# --- SİSTEM 2: SAF D'HONDT ---
def run_dhondt_model(total_seats):
    seats = [0] * len(DISTRICTS)
    
    for _ in range(total_seats):
        max_quotient = -1
        winner_index = -1
        
        for i in range(len(DISTRICTS)):
            quotient = POPULATIONS[i] / (seats[i] + 1)
            if quotient > max_quotient:
                max_quotient = quotient
                winner_index = i
                
        seats[winner_index] += 1
        
    return calculate_unfairness(seats, total_seats)

# --- GELİŞMİŞ ANALİZ VE GRAFİK ÇİZİMİ ---
def main():
    TARGET_SEATS = 600
    print(f"Simülasyon başlatılıyor... (1-{TARGET_SEATS} vekil senaryosu)")
    
    x_values = list(range(1, TARGET_SEATS + 1))
    y_iterative = []
    y_dhondt = []
    
    for v in x_values:
        y_iterative.append(run_iterative_model(v))
        y_dhondt.append(run_dhondt_model(v))
        
    # --- PROFESYONEL GRAFİK AYARLARI ---
    plt.figure(figsize=(16, 8)) # Daha geniş ve detaylı tuval
    
    # Çizgi 1: D'Hondt
    plt.plot(x_values, y_dhondt, color='#d62728', linestyle='-', linewidth=1.5, label="Sistem 2: Saf D'Hondt", alpha=0.8)
    
    # Çizgi 2: Yinelemeli Model
    plt.plot(x_values, y_iterative, color='#2ca02c', linewidth=2.5, label="Sistem 1: Yinelemeli Hakkaniyet Modeli")
    
    # DETAY: "Equity Gap" (Adalet Kazancı) Alanını Boyama
    # Yeşil çizgi ile Kırmızı çizgi arasındaki alanı boyayarak farkı vurgular
    plt.fill_between(x_values, y_iterative, y_dhondt, color='#2ca02c', alpha=0.15, label="Yinelemeli Hakkaniyet Modelinin Adalet Kazancı")

    # Grafik Süslemeleri
    plt.title(f"Seçim Sistemleri Adalet Duyarlılık Analizi (1 - {TARGET_SEATS} Vekil)", fontsize=16, fontweight='bold')
    plt.xlabel("Toplam Meclis Üyesi Sayısı", fontsize=12)
    plt.ylabel("Adaletsizlik Puanı (Düşük = Daha İyi)", fontsize=12)
    
    # Grid Ayarları (Daha detaylı ızgara)
    plt.grid(True, which='major', linestyle='-', alpha=0.6)
    plt.grid(True, which='minor', linestyle=':', alpha=0.3)
    plt.minorticks_on()
    
    # Son Noktayı İşaretle (600. Vekil Durumu)
    last_val_b = y_iterative[-1]
    last_val_d = y_dhondt[-1]
    plt.scatter(TARGET_SEATS, last_val_b, color='green', s=100, zorder=5)
    plt.scatter(TARGET_SEATS, last_val_d, color='red', s=100, zorder=5)
    
    # Notasyon ekle
    plt.annotate(f'%{last_val_b:.2f}', (TARGET_SEATS, last_val_b), xytext=(10, -10), textcoords='offset points', color='green', fontweight='bold')
    plt.annotate(f'%{last_val_d:.2f}', (TARGET_SEATS, last_val_d), xytext=(10, 10), textcoords='offset points', color='red', fontweight='bold')

    plt.legend(loc='upper right', fontsize=11, frameon=True, shadow=True)
    
    # Grafiği Kaydet
    filename = "Adalet_Karsilastirma_600_Detayli.png"
    plt.savefig(filename, dpi=300, bbox_inches='tight')
    print(f"Detaylı grafik '{filename}' olarak kaydedildi.")
    plt.show()

if __name__ == "__main__":
    main()
