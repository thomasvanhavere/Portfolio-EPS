<?php 
	

	//$operation = $_GET["op"];
	$username = "";
	$password = "";
	$xmlFile = simplexml_load_file("php_project.xml");
	$xmlLocalCopy = new SimpleXMLElement($xmlFile->asXML());
	$username = $_GET["username"];
	$password = $_GET["password"];

	
	$newAcct = $xmlLocalCopy->addChild("Account");	
	$newAcct->addChild("username", $username);
	$newAcct->addChild("password", $password);
		

	$dom = new DOMDocument('1.0');
	$dom->preserveWhiteSpace = false;
	$dom->formatOutput = true;
	$dom->loadXML($xmlLocalCopy->asXML());
	$dom->save("php_project.xml");
	
	echo "Account Created.%login.html";
	header("Location:Maps.html");
		
?>
