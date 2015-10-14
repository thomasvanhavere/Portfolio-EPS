using SdlDotNet.Audio;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Motherload
{
    class Manager
    {
        private Surface mVideo;//hoofd surface
        private Player speler; 
        private List<GameObject> gameObjecten;
        private Level level;
        private CollisionDetection col;
        private RemoveDirt removeDirt;
        private DateTime Time;
        private TimeSpan Remaining = new TimeSpan(0,0,0,0,1);
        private Audio play;
        private Surface[] start = new Surface[5]; //Verschillende keuzes(1ste startscherm)
        private Surface[] VerschillendeLevels = new Surface[5];// //Verschillende keuzes(2de startscherm)
        private Surface startaf;
        private Surface score;
        private Surface Timer;
        private Surface Levelkeuze;
        private Surface LoseScreen;
        private  bool Free = false;
        private bool startMenu = true;
        private bool levela = false;
        private bool end = false;
        private bool Level1 = false, Level2 = false, go = false;              
        private LoadLevel laad;
        private SdlDotNet.Graphics.Font font42 = new SdlDotNet.Graphics.Font(@"Arial.ttf", 42);//ariel fond 42 groot
        private SdlDotNet.Graphics.Font font32 = new SdlDotNet.Graphics.Font(@"Arial.ttf", 32);//ariel fond 32 groot
        private Point beweeg = new Point(0, 450);//startpunt voor bewegen rechthoek (1ste startscherm)
        private Box selctieboxje = new Box(new Point(0, 450), new Size(750, 50)); //aanmaken rechthoek om selecteren (1ste startscherm)
        private Box selctieboxje2 = new Box(new Point(0, 300), new Size(750, 50));//aanmaken rechthoek voor selectie (2de startscherm)
        private Box[] LevensBoxen = new Box[6];//Levensrecthoeken
        private List<Box> Levens = new List<Box>();
        private Color kleur = Color.Green;
        private CheatEngin Cheater;
        private bool PlayBoem = true, PlayYha = true;
        private int textvalue = 250;
        public bool esc = false;
        Thread audioThread;
        TimeSpan vast = new TimeSpan(0, 0, 3, 0, 0);
        TimeSpan temp;
        public Manager()
        {
            play = new Audio(); //aanmaken audio
            audioThread = new Thread(new ThreadStart(play.PlayAudio));//starten tread
            laadTextarrays();//Aanmaken van textblock voor beginscherm
            startaf = new Surface("motherload_logo.png");//toewijzen van afb(1ste startscherm)
            Levelkeuze = new Surface("motherload_logo2.png");//toewijzen van afb(2de startscherm)
            LoseScreen = new Surface("explosion.png"); //Toewijzen afb eindscherm
            mVideo = Video.SetVideoMode(750,600);//Grote van window instellen
            Video.WindowCaption = "Motherload"; //Titel in titelbalk instellen
            speler = new Player();//aanmaken van speler
            level = new Level();//aanmaken van level
            gameObjecten = new List<GameObject>();
            col = new CollisionDetection();//aanmaken van nieuw collisionDetection
            removeDirt = new RemoveDirt();//Aanmaken van Removedirt
            gameObjecten.Add(speler);
            laad = new LoadLevel();       
            Cheater = new CheatEngin();
            audioThread.Start();   
            CreerLevens();    
            Events.Fps = 60;
            Events.KeyboardDown += Events_KeyboardDown;
            Events.Quit += Events_Quit;
            Events.Tick += Events_Tick;          
            Events.Run();           
        }

        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        { 
            if (startMenu == true)//Mag het startlenu getoont worden
            {
                if (e.Key == SdlDotNet.Input.Key.UpArrow)//freemode Up
                {
                    if (beweeg.Y > 450)
                        beweeg.Y -= 50;

                    selctieboxje = new Box(beweeg, new Size(750, 50));
                }
                if (e.Key == SdlDotNet.Input.Key.DownArrow) //Down
                {
                    if (beweeg.Y < 550)
                        beweeg.Y += 50;
                    selctieboxje = new Box(beweeg, new Size(750, 50));
                }
            }
                if (levela == true) //kan het twede startscherm getoond worden
                {
                    if (e.Key == SdlDotNet.Input.Key.UpArrow)//freemode Up
                    {
                        if (levela == true)
                            if (textvalue < 250)
                                textvalue += 50;
                    }
                    if (e.Key == SdlDotNet.Input.Key.DownArrow) //Down
                    {
                        if (levela == true)
                            if (textvalue > 100)
                                textvalue -= 50;
                    }
                }
                if(e.Key == SdlDotNet.Input.Key.Escape)
                {
                    if ((Remaining.TotalMilliseconds <= 0 || speler.Levens <= 0) && end == true)
                    {
                        play.StopMusic();
                        esc = true;
                        Events.QuitApplication();
                        PlayBoem = true;
                        PlayYha = true;     
                    }
                    if(col.GameEnd || Cheater.Enough)
                    {
                        speler = new Player();
                        level = new Level();
                        gameObjecten = new List<GameObject>();
                        col = new CollisionDetection();
                        removeDirt = new RemoveDirt();
                        gameObjecten.Add(speler);
                        laad = new LoadLevel();
                        CreerLevens();
                        levela = true;
                        Level1 = false;
                        Level2= false;
                        PlayBoem = true;
                        PlayYha = true;
                        kleur = Color.Green;
                        
                    }   
                }
            if(e.Key==SdlDotNet.Input.Key.F1)
            {
                Cheater.CheatBaar = true;
            }
                if (e.Key == SdlDotNet.Input.Key.Return)
                {
                    if (startMenu ==true)
                    {
                        if (beweeg.Y == 550)
                        {
                            Events.QuitApplication();
                        }
                        else if (beweeg.Y == 500)
                        {
                            levela = true;
                            startMenu = false;
                            go = false;
                        }
                        else if (beweeg.Y == 450)
                        {
                            laad.LevelFile = "Level.txt";
                            initialize();
                            Free = true;
                            end = true;
                            go = false;
                        }
                    }
                    if(levela == true)
                    {
                        if(textvalue == 100)
                        {
                            Events.QuitApplication();
                        }
                        else if(textvalue ==150)
                        {
                            levela = false;
                            Free = false;
                            beweeg.Y = 450;
                            textvalue = 250;
                            startMenu = true;
                            go = false;
                        }
                        else if(textvalue ==200)
                        {
                            laad.LevelFile = "Level2.txt";
                            initialize();
                            Time = DateTime.Now;
                            Level2 = true;
                            levela = false;
                            end = true;
 
                        }
                        else if(textvalue == 250 && go ==true)
                        {
                            laad.LevelFile = "Level1.txt"; 
                            initialize();
                            Time = DateTime.Now;
                            end = true;
                            Level1 = true;
                            levela = false;
                        }
                        go = true;
                    }
                    
                }
            
        }
        private void initialize()
        {
            laad.ReadLevel();
            level.inttileArray = laad.GetMatrix;
            level.CreateWorld();
        }
        void Events_Quit(object sender, QuitEventArgs e)
        {
            Console.WriteLine("Sluiten...");
            Events.QuitApplication();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            if (Free == true) //Play Free Mode(beta)
            {
                score = font42.Render("Score : " + removeDirt.Score.ToString(), Color.Wheat);
                removeDirt.Removedirt(speler, level);
                BasicLevel();
                DispLevens();
                mVideo.Blit(score, new Point(250, 0));
            }
            else if(startMenu == true)//weergave startmenu
            {
                mVideo.Fill(Color.Black);
                selctieboxje.Draw(mVideo,Color.White);
                mVideo.Blit(startaf, new Point(0, 150));
                for (int i = 2; i<5;i++)
                {
                     mVideo.Blit(start[i], new Point(200, 350+(i*50)));
                } 
            }
            if (Level1 == true || Level2 == true)//Sweergeven level1 of2
            {
                BasicLevel();
                DispLevens();
                timerInit();
                scoreTeller(); 
            }
            else if (levela == true)//wergeven van 2de beginscherm
            {
                SplashScreen();
            }
            if(col.GameEnd || Cheater.Enough)//game gewonnen
            {
                WinGame();
            }
            if((Remaining.TotalMilliseconds<=0 || speler.Levens <=0) &&  end == true && Cheater.inflifes==false) //verloren
            {
                Losegame();       
            }
            if(Cheater.CheatBaar==true)//cheartengin aan/uit
            {
                Cheater.ShowSheartEngin();
            }
            if(Cheater.Fly)//vliegen ja/nee
            {
                speler.FlayAble = true;
            }
          mVideo.Update();      
        }
    
        public void WinGame()
        {
            mVideo.Fill(Color.Black);
           
          
            score = font42.Render("Winner !!!!!\n ", Color.Wheat); 
            mVideo.Blit(score, new Point(250, 50));
            score = font32.Render("In:" + temp.ToString() , Color.Wheat);
            mVideo.Blit(score, new Point(50, 100));
            score = font32.Render("Met een score van :" + col.Score.ToString() + " \n-------------------------------------------", Color.Wheat);
            mVideo.Blit(score, new Point(50, 150));
            score = font32.Render("Now stare at this until you know you did well:p \n \n Rate this game \n ING 10/10 Best game ever \n\n press esc...", Color.Wheat);
            mVideo.Blit(score, new Point(50, 200));
            if (PlayYha)
            {
                PlayYha = false;
                play.YheayBaby();
            }
        
        }
        private void SplashScreen()
        {
            mVideo.Fill(Color.Black);
            selctieboxje2.Draw(mVideo, Color.White);
            mVideo.Blit(Levelkeuze, new Point(175, 75));
            for (int i = 1; i < 5; i++)
            {
                mVideo.Blit(VerschillendeLevels[i], new Point(300, textvalue + (i * 50)));
            }
        }
        private void Losegame()
        {
            mVideo.Fill(Color.Black);
            mVideo.Blit(LoseScreen, new Point(0, 0), new Rectangle(new Point(300, 50), new Size(750, 600)));
            score = font32.Render("Lol moe ik opnieuw beginnen :) Press ESC...", Color.Wheat);
            mVideo.Blit(score, new Point(75, 550));
            if (PlayBoem)
            {
                play.playBoem();
                PlayBoem = false;
            }   
        }
        private void laadTextarrays()
        {
            start[2] = font42.Render("Play Free Mode(beta)", Color.White);
            start[3] = font42.Render("Play Costum level", Color.White);
            start[4] = font42.Render("Quit !! ", Color.White);

            for (int i = 0; i < 4; i++)
            {
                VerschillendeLevels[i] = font42.Render("Level " + i.ToString(), Color.White);
            }
            VerschillendeLevels[3] = font42.Render("Return", Color.White);

            VerschillendeLevels[4] = font42.Render("Quit", Color.White);
            
        }
        private void DispLevens()
        {
            CreerLevens();
          
            if (speler.Levens <= 3 && speler.Levens>1)
                kleur = Color.Orange;
            else if (speler.Levens == 1)
                kleur = Color.Red;
            foreach(Box B in Levens)
            {
                B.Draw(mVideo, kleur, false, true);
            }
        }
        private void CreerLevens()
        {
            Levens.Clear();
            for (int i = speler.Levens; i >0; i--)
            {  
                LevensBoxen[i] = new Box( new Point(25,25+(i*25)),new Size(50,20));
                Levens.Add(LevensBoxen[i]);
            }
        }
        private void BasicLevel()
        {
            level.MoveLevel(speler);
            mVideo.Fill(Color.Chocolate);
            col.Collisiondetection(speler, level);
            level.Draw(mVideo);
            
            foreach (GameObject g in gameObjecten)
            {
                g.Update();
                g.Draw(mVideo);
            }
            foreach (Dirt D in level.dirtobject)
            {
                D.Update();
            }
            foreach (Leeg L in level.leegObject)
            {
                L.Update();
            }
            foreach(Diamant D in level.DiamantObj)
            {
                D.Update();
            }
            foreach (Finale f in level.Finish)
            {
                f.Update();
            }
          
        }
        private void timerInit()
        {
         
            TimeSpan min = Time - DateTime.Now;
            if(Cheater.TimeMaster==false)
            {
                Remaining = vast + min;
                
            }
            else
            {
                
            }
            if(col.GameEnd ==false)
                temp = vast - Remaining;

            Timer = font32.Render("Time Left : " + Remaining.Minutes + " : " + Remaining.Seconds + " : " + Remaining.Milliseconds, Color.Wheat);
            mVideo.Blit(Timer, new Point(50, 0));
        }
        private void scoreTeller()
        {

            if (speler.Levens < 5)
            {
                if (col.ExtraLeven == true)
                {
                    speler.Levens += 1;
                    col.ExtraLeven = false;
                }
            }
            else if (speler.Levens == 5)//Beperkt levens to 5
                col.ExtraLeven = false;

            if(Cheater.UltiScore)
            {
                col.Score += 999999999;
                Cheater.UltiScore = false;
            }
            score = font32.Render("Score : " +col.Score.ToString(), Color.Wheat);
            mVideo.Blit(score, new Point(400, 0));
               
        }
    }

}
