<?php
    session_start();
    $php_project = simplexml_load_file("php_project.xml");

    $login = "";
    $password = "";
    $loginname = "";

    for($i = 0; $i < count($php_project); $i++){

        $username = $php_project->Account[$i]->username;
        $password = $php_project->Account[$i]->password;
       


    if(empty($_POST["username"]) || empty($_POST["password"]))
    {	
        header("Location:wrong.html");
		//return false;
    }
	

        if(($_POST["username"] == $username) && ($_POST["password"] == $password)){
            
            header("Location:Maps.html");
		
        }
		else
		{
			header("Location:wrong.html");
		}
    }


   
 ?> 