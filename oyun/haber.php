<?php
// Hürriyet gazetesinin RSS beslemesinin URL'si
$rssFeedUrl = "https://www.hurriyet.com.tr/rss/anasayfa";

// cURL oturumu başlat
$ch = curl_init();

// URL'yi cURL'e ayarla
curl_setopt($ch, CURLOPT_URL, $rssFeedUrl);

// Dönen değeri string olarak döndür (doğrudan ekrana yazdırma)
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);

// cURL isteğini çalıştır ve sonucu al
$response = curl_exec($ch);

// cURL oturumunu kapat
curl_close($ch);

// XML yanıtını diziye dönüştür
$xml = simplexml_load_string($response);

// Haber başlıklarını al
$newsTitles = array();
foreach ($xml->channel->item as $item) {
    $title = (string)$item->title;
    $newsTitles[] = $title;
}

// JSON olarak haber başlıklarını dön
header('Content-Type: application/json');
echo json_encode($newsTitles);
?>
