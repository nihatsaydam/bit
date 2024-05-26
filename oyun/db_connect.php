<?php
$servername = "localhost";
$username = "root"; // Veritabanı kullanıcı adınızı girin
$password = ""; // Veritabanı şifrenizi girin
$dbname = "oyun"; // Veritabanı adınızı girin

// MySQL bağlantısını oluştur
$conn = mysqli_connect($servername, $username, $password, $dbname);

// Bağlantı hatası kontrolü
if (!$conn) {
    die("Veritabanı bağlantısı başarısız: " . mysqli_connect_error());
}
?>