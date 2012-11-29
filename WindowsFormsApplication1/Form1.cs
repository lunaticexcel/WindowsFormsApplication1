﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        //時間経過をはかるためのクラス
        Stopwatch myStopWatch = new Stopwatch();
        //スタート・ストップボタン用
        Boolean sw = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //各コントロールのプロパティを設定する

            //フォームのプロパティ
            this.Size = new Size(300, 180);
            this.Text = "ストップウォッチ";

            //ラベルのプロパティ
            this.label1.Text = myStopWatch.Elapsed.ToString();
            this.label1.BackColor = Color.White;
            this.label1.Font = new System.Drawing.Font("富士ポップ", 36);
            this.label1.BorderStyle = BorderStyle.Fixed3D;
            this.label1.Location = new Point(0, 9);
            this.label1.Size = new Size(290, 50);
            this.label1.TextAlign = ContentAlignment.TopCenter;
            this.label1.AutoSize = false;

            //スタート・ストップボタンのプロパティ
            this.button1.Text = "スタート";
            this.button1.Size = new Size(85, 30);
            this.button1.Location = new Point(40, 100);

            //リセットボタンのプロパティ
            this.button2.Text = "リセット";
            this.button2.Size = new Size(85, 30);
            this.button2.Location = new Point(160, 100);
            this.button2.Enabled = false;

            //表示更新用タイマーのプロパティ
            this.timer1.Interval = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //スイッチがoff（計測開始していない）とき
            if (sw == false)
            {
                //計測開始
                myStopWatch.Start();
                //表示更新タイマー開始
                timer1.Start();
                //スイッチon
                sw = true;
                //リセットボタン使用不可
                button2.Enabled = false;
                //「スタート」だったボタンの表示を「ストップ」に変更
                button1.Text = "ストップ";
            }

            //スイッチがoff以外のとき（つまりはonのとき）
            else
            {
                //計測終了
                myStopWatch.Stop();
                //表示固定
                timer1.Stop();
                //スイッチoff
                sw = false;
                //リセットボタン使用可
                button2.Enabled = true;
                //「ストップ」だったボタンの表示を「スタート」に変更
                button1.Text = "スタート";
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //ストップウォッチの内容をゼロにする
            myStopWatch.Reset();
            //リセットした状態をlabel1に表示する
            label1.Text = myStopWatch.Elapsed.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //label1にスタートから現在までの時間を表示させる
            label1.Text = myStopWatch.Elapsed.ToString();
        }
    }
}
