<?php
// Binance API URL
$apiUrl = "https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDT";

// cURL oturumu başlat
$ch = curl_init();

// URL'yi cURL'e ayarla
curl_setopt($ch, CURLOPT_URL, $apiUrl);

// Dönen değeri string olarak döndür (doğrudan ekrana yazdırma)
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);

// cURL isteğini çalıştır ve sonucu al
$response = curl_exec($ch);

// cURL oturumunu kapat
curl_close($ch);

// JSON yanıtını diziye dönüştür
$data = json_decode($response, true);

// JSON yanıtı döndür
header('Content-Type: application/json');
echo json_encode($data);
?>
