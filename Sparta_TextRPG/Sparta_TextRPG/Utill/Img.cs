﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NAudio.Wave; // NAudio를 꼭 using 해야 함

namespace Sparta_TextRPG.Utill
{
    internal class Imgs
    {
        private static Imgs instance;
        public static Imgs Instance()
        {
            if (instance == null)
            {
                instance = new Imgs();
            }
            return instance;
        }

        public void Onewin()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string musicPath = "Bgm\\NewNexonLogin.mp3";

            // BGM 재생
            if (!File.Exists(musicPath))
            {
                Console.WriteLine("BGM 파일을 찾을 수 없습니다: " + musicPath);
            }
            else
            {
                using (var audioFile = new AudioFileReader(musicPath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    

                    // --- 로고 출력 ---
                    Console.WriteLine("""                               
                
                
                                      ⠡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⠡⠡⡡⡑
                                      ⢅⢕⠑⠌⢌⢪⣨⣼⡼⡾⢾⠷⠾⢾⠾⡼⣬⣮⣌⣌⡌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⠌⢌⢂⢂
                                      ⡂⡢⣡⣵⠷⢛⠉⠄⠄⡂⢄⢇⠣⡢⡒⢔⠔⡄⢍⠉⠛⠻⢾⣴⣑⡐⠅⠅⠅⢅⢑⢐⠅⠅⠅⢅⢑⢐⠅⠅⠅⢅⢑⢐⠅⠅⢅⢑⠄⠅
                                      ⢢⡾⠏⡡⡘⠔⡈⠄⡁⡢⡣⡑⢕⢌⠪⡢⢱⢘⢌⢂⠠⠀⠠⢈⠙⠻⣮⣎⡌⡂⡢⠢⠡⡑⢅⢑⢐⠅⢅⢑⢅⢑⢐⠅⠅⠅⠕⠄⠅⢕
                                      ⡟⢧⣑⢌⡪⡠⡢⡣⢣⠱⡨⡊⢆⢕⠱⡨⢢⠱⡨⢪⢘⠔⡔⢔⠱⡑⡤⠝⠿⣷⣬⡌⡌⢌⢂⠢⠢⠡⡑⡐⡐⢔⠐⢅⢑⠅⠕⠅⠕⢅
                                      ⡨⡲⡱⣱⠱⡑⡌⡪⢢⠱⡨⡊⢆⢕⠱⡘⢔⠱⡨⢢⢑⠕⡌⢆⠣⡑⣅⠂⡂⠄⡉⠛⠿⣶⣆⡅⠅⢕⠐⠌⢌⠢⠡⡑⠄⢅⠅⢅⢕⢐
                                      ⡪⣪⢣⡣⡣⢱⠨⡊⢆⠣⣊⢎⠆⠇⠇⠎⠎⠎⢎⢆⡕⡱⡨⠢⡣⠱⡐⢝⢔⢄⢂⠁⡂⢈⠙⠻⣿⣦⣥⢡⠡⠡⡑⠌⢌⠢⠡⡑⡐⡐
                                      ⡫⡪⣪⢪⢊⢆⠣⡱⡱⢉⠂⡂⠌⠄⠡⠁⠅⡁⡂⡐⡈⠪⡪⢪⢘⢌⠪⡢⡑⢅⠣⡣⡢⣐⡐⡠⡐⡌⠙⠻⢷⣵⣌⢌⠢⠡⡑⡐⢔⢐
                                      ⡎⣇⢇⢇⠪⡢⡓⡁⡂⡐⢐⠠⠡⠈⠌⠨⢐⢀⢂⠐⠠⢁⢇⢕⢥⢣⡣⣪⢪⡪⣪⢲⢱⢲⢸⢌⢎⢜⠰⣀⢀⠈⠙⢷⣕⡑⡐⢌⢂⢂
                                      ⡮⡪⡪⡣⡱⡃⡐⡀⢂⢐⠠⠈⠄⠡⠁⠅⡂⡐⢄⠪⡨⡪⡣⡏⣎⢇⢧⢣⢇⢗⡕⣝⢜⡕⣇⢗⢝⡜⣝⢜⡲⡰⡀⠀⠹⣮⡊⡂⡢⡂
                                      ⣇⢏⢎⢆⢳⠀⡂⡐⡀⠂⠌⠨⠈⠄⢅⢑⠔⢌⠢⡱⡜⣎⣧⣫⣮⢷⡷⣻⣞⢷⣻⢞⡷⡷⣷⣳⣵⣝⡜⣎⢮⢳⢹⢔⠀⢻⣎⢆⢂⢂
                                      ⡪⣪⢣⢑⢵⡐⡀⡂⠄⠡⠡⡡⡑⢅⢕⢐⣅⢧⣯⡾⡯⣟⡾⡵⡯⡿⡽⣵⣫⢯⢾⢽⡽⡯⣗⡯⡾⡽⡽⣮⡪⣎⢧⢳⡁⠸⣿⢐⡑⡐
                                      ⡝⣜⢜⢔⢅⢣⢲⢔⡥⡣⣕⣔⢼⢔⣗⣽⢞⢛⢕⠫⡋⡫⡙⡙⠝⢝⢛⠳⠷⢯⣯⡷⣯⡻⡮⡯⡯⣫⢯⣗⣯⢎⢮⡪⡎⢨⣿⠢⡂⡊
                                      ⡳⡱⡱⣕⡕⣗⢭⢇⢯⡺⣪⣞⡾⠻⡙⡐⡱⡐⢅⠕⢌⠢⠪⡨⡊⡢⡡⡑⢅⢕⢐⢝⢳⣯⢯⢯⢯⢯⣳⣳⣻⡪⣣⢣⢃⣼⡏⢜⢐⢐
                                      ⡪⡮⡳⡕⠽⡸⡪⣫⣗⠯⠏⢕⢌⢊⠢⡑⠔⢌⠢⡑⢅⢕⢑⠔⢌⠢⠢⡊⡢⠢⡑⢔⢐⢝⣯⣟⣽⣫⢟⣾⡳⡹⡜⢰⣼⢟⢌⠢⡑⡐
                                      ⡋⡪⡂⣪⣬⡶⠻⡙⡐⣑⢑⢕⢰⣵⣵⠨⡊⡢⠑⠌⠢⠢⠡⠑⠡⠑⠑⠨⠈⠪⠨⣢⡑⠔⢿⣾⣺⣺⣽⢺⠜⣕⣼⢟⠣⡑⡐⡑⡐⡐
                                      ⣬⡶⢟⢋⢆⠪⡨⠢⡑⠔⠔⠅⢿⣿⣿⠇⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⠄⠈⢿⣾⢹⣸⣼⠾⡫⠣⠡⡑⡐⢌⢂⠪⠨
                                      ⡑⢌⠢⡑⢔⢑⠌⢊⠈⢄⠠⡀⡈⠛⠊⠀⠀⠀⠀⠈⢸⣀⢀⢀⣢⣶⡀⡀⣕⠀⠀⠙⠟⡁⡀⡈⢿⣯⠱⡐⡑⠌⢌⢌⠢⠨⡂⠢⠡⡑
                                      ⢌⠢⡑⢌⠢⡁⢌⠐⢌⢐⢐⠐⢄⢑⠀⠠⠐⠀⠀⠈⠀⢉⣿⡿⣟⣯⣿⡉⠀⠀⠠⡈⡂⡂⡂⡂⠅⡻⣧⡒⠌⢌⢂⠢⠡⡑⠌⢌⠌⢌
                                      ⠢⡑⢌⠢⡑⡀⠀⠑⢐⠐⡐⠨⠐⠐⠀⠀⠀⠀⠀⠠⠀⠀⣿⢽⢝⡽⣽⠂⠀⠀⠀⠐⠐⠐⠐⠄⠑⠀⠹⣧⡣⡑⠄⠅⠕⠌⢌⠢⠡⠡
                                      ⡑⢌⠢⡑⢌⠄⠀⠀⠀⠀⠀⠀⠀⢀⠀⠠⠀⠐⠀⠀⠀⠀⠙⠗⠟⠞⠃⠀⠀⠀⠂⠀⠀⠐⠀⠀⠀⡀⠀⠹⣷⢌⢌⠪⠨⠨⠢⠡⠡⡑
                                      ⢌⠢⡑⢌⠢⡂⠀⠀⠄⣂⠀⠐⠈⣀⠀⠀⠀⠀⢀⠀⡄⡀⠀⡀⡀⡀⣀⠀⢀⣀⣀⠄⠐⠀⠀⠀⠁⠀⠀⠀⢻⣷⢐⠅⠅⠕⢅⢑⢑⢌
                                      ⠢⡑⢌⠢⡑⠄⠀⠀⠈⢸⠄⢐⣚⣉⣓⡂⠀⡀⠬⢝⠻⢭⠀⠈⣹⠁⣷⢀⣘⡦⣴⣃⠀⣠⡀⡄⢀⣄⢠⠀⠈⣿⡆⡣⠡⡡⡑⡐⢔⢐
                                      ⠪⡨⠢⡑⢌⠂⠀⠀⠐⠜⠆⠀⢖⣂⡲⠄⠀⠀⠉⠉⡏⠉⠁⠚⠁⠀⣗⠀⣀⠵⢦⣀⠀⠀⠈⠀⠀⠀⠁⠀⠀⣿⡇⡪⡈⡂⡂⡊⡂⡢
                                      ⢕⢌⠪⡨⠢⡁⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⢀⠀⠀⠀⣿⡇⡪⠢⠨⡂⡊⡂⡂
                             
                             
                """);

                    // --- 기다리는 시간 ---
                    Thread.Sleep(4500); // 8초 동안 로고 + 브금 보여줌 (원하면 10초로 조정 가능)
                    Console.Clear();
                }
            }
        }
    }
}


