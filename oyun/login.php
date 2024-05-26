x<?php
require_once 'db_connect.php';

$username = $_POST['username'];
$password = $_POST['password'];

// Kullanıcıyı veritabanından kontrol et
$query = "SELECT * FROM user WHERE user='$username' AND pass='$password'";
$result = mysqli_query($conn, $query);

if (mysqli_num_rows($result) > 0) {
    echo json_encode(array("action" => "giris islemi basarili harika bir is cikardiniz "));
} else {
    echo json_encode(array("message" => "Kullanıcı adı veya şifre yanlış"));
}

mysqli_close($conn);
?>