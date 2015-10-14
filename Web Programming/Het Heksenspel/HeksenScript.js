

	$(function () {
      	var VallendeSter = new Array();
		 var vy =Math.floor((Math.random() * 10) + 1);
		 var verloren = 10;
		 
		 var score=0;
		 var straal=30;
        var canvas = document.getElementById("canvas");
        var ctx = canvas.getContext("2d");
        var img = new Image();
        img.src = "Images/heks.png"
 		evil = new heks(20,4);
		
		var image = new Image();
		image.src ="Images/Ster_Groot.png";
		
		function creerster(x)
		{
			vy=Math.floor((Math.random() * 10) + 1);
		straal =30+Math.floor((Math.random() * 30) + 1);
			VallendeSter[x] = new ster(0,15,vy,straal);
			VallendeSter[x].x =  Math.floor((Math.random() * 1000) + 1);
			
			VallendeSter[x].vy = 0.5+ vy;
		}
		
		for (var i=0;i<10;i++)
		{ 
		straal =30+Math.floor((Math.random() * 30) + 1);
		vy=Math.floor((Math.random() * 5) + 1);
			VallendeSter[i] = new ster(0,15,vy,straal);
			VallendeSter[i].x =  Math.floor((Math.random() * 1000) + 1);
		
			VallendeSter[i].vy = 0.5+ vy;
		}
		
		
		animate();
		
 	function heks(x,y) {
            this.x = x;
            this.y = y;

            this.Teken = function () {
                ctx.drawImage(img, this.x, this.y, 60,32);
					
            }
        }
		function ster(x,y,vy,straal) {
           straal=straal || 30;
		    vy = vy || 1;
		    this.straal = straal;
			this.x = x ;
            this.y = y;
			 this.vy = vy;
            this.Teken = function () {
                ctx.drawImage(image, this.x, this.y, straal,straal);

            }
        }
		function tekenSterren( )
		{
			
			
	 	for (var i=0;i<10;i++)
		{ 
			if (VallendeSter[i].y >600)
			{
			creerster(i);
			verloren--;
			if(verloren ==0)
			{
				alert("je hebt verloren");
				score = 0;
				verloren=0;
				location.reload();
			}
			}
			else if ((VallendeSter[i].x<evil.x+60)&&(VallendeSter[i].x+30>evil.x)&&(VallendeSter[i].y<evil.y+32)&&(VallendeSter[i].y+30>evil.y					))
			{
				creerster(i);
				score++;
				if (score ==50)
				{
				alert("Je hebt gewonnen")
				score = 0;
				verloren=0;
				location.reload();
				}
			}
			else
			{
				//if (VallendeSter[i].straal=>30&&VallendeSter[i].straal<40
			VallendeSter[i].y += (VallendeSter[i].straal/100)+1;
			VallendeSter[i].Teken();
			}
		}
		
            
		
		}
 function animate() {
            ctx.clearRect(0, 0, 1000, 600);
           
           $("canvas").mousemove(function (event) {
            var ywaarde = event.pageY-25;
            evil.y = ywaarde;
			var xwaarde = event.pageX -25;
			evil.x=xwaarde;
			
        });
		
		ctx.font=("Bold 100px arial")
   		 ctx.fillText(score, 450,250)
			tekenSterren();
            evil.Teken();
			var nodig = 50-score;
            setTimeout(animate, 10);
			 div1.innerHTML = "Je hebt nog " + verloren +"levens";
			  div2.innerHTML = "Je hebt nog " + nodig +"punten nodig om te winnen ;-)";
			tekenSterren();
			
		
         

        }
    
        });


