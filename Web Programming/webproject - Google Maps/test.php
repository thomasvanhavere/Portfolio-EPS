<?php
session_start();
//logout
if(isset($_GET['logout'])){unset($_SESSION['logged_in']);session_destroy();}
?> 