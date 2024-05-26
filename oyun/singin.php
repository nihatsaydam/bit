<?php
require_once 'db_connect.php';

$mail = $_POST['mail'];
$username = $_POST['username'];
$password = $_POST['password'];
$soru = $_POST['soru'];
$sql = "INSERT INTO user (user, pass,mail,soru) VALUES ('$username', '$password','$mail','$soru')";
$result = mysqli_query($conn, $sql);
if ($result !== false) {
    echo json_encode(array("action" => "onay"));
} else {
    echo json_encode(array("action" => "iptal", "error" => mysqli_error($conn)));
}
?>
