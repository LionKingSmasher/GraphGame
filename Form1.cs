using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphGame
{
    public partial class Form1 : Form
    {
	   public bool loop = false;
	   public int in_money = 0;
	   public int in_present_money = 0;
	   public int present_money = 1000000;
	   public int result_1 = 0;
	   public int result = 0;
	   public int in_percent = 0;
	   public int in_present_percent = 0;
	   public int pm = 0;
	   public double in_ = 0;
	   public Form1()
	   {
		  InitializeComponent();
	   }
	   public void Start()
	   {
		  Random r = new Random();
		  pm = r.Next(1, 100);
		  result_1 = r.Next(0, 250);
		  if (pm % 2 == 0)
		  {
			 result -= result_1;
			 listBox1.Items.Add(result_1 + "만큼 줄었습니다.");
		  }
		  else if (pm % 2 == 1)
		  {
			 result += result_1;
			 listBox1.Items.Add(result_1 + "만큼 늘었습니다.");
		  }
		  chart1.Series["Graph"].Points.Add(result);
		  chart1.Update();
		  //Delay(6500);
		  //Thread.Sleep(7500);
	   }
	   private void button1_Click(object sender, EventArgs e) //매수 버튼
	   {
		  string input_s = textBox1.Text;
		  present_money -= Int32.Parse(input_s);
		  in_percent = result;
		  listBox2.Items.Clear();
		  wallet();
	   }

	   private void button2_Click(object sender, EventArgs e) //매도 버튼
	   {

	   }

	   private void button3_Click(object sender, EventArgs e) //그래프 시작 버튼
	   {
		  Series s1 = new Series("Graph");
		  chart1.Series.Add(s1);
		  chart1.Series["Graph"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.ThreeLineBreak;
		  timer1.Enabled = true;
		  loop = true;
	   }

	   private void button4_Click(object sender, EventArgs e) //그래프 종료 버튼
	   {
		  chart1.Series.Clear();
		  loop = false;
		  timer1.Enabled = false;
	   }

	   private void timer1_Tick(object sender, EventArgs e)
	   {
		  Go();
		  listBox2.Items.Clear();
		  wallet();
		  if (in_percent != 0)
		  {
			 in_ = (float)result / in_percent;
		  }
		  else
		  {
			 in_ = 0;
		  }
	   }
	   private void Go()
	   {
		  if(loop == true)
		  {
			 timer1.Enabled = false;
		  }
		  Start();
		  if(loop == true)
		  {
			 timer1.Enabled = true;
		  }
	   }

	   private static DateTime Delay(int MS)
	   {
		  DateTime ThisMoment = DateTime.Now;
		  TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
		  DateTime AfterWards = ThisMoment.Add(duration);
		  while (AfterWards >= ThisMoment)
		  {
			 System.Windows.Forms.Application.DoEvents();
			 ThisMoment = DateTime.Now;
		  }
		  return DateTime.Now;
	   }
	   private void wallet()
	   {
		  listBox2.Items.Add("###################################");
		  listBox2.Items.Add("[지갑]");
		  listBox2.Items.Add("현재 잔액: " + present_money);
		  listBox2.Items.Add("현재 이익률: " + ((in_ - 1)*100) + "%");
		  listBox2.Items.Add("###################################");
	   }

	   private void button5_Click(object sender, EventArgs e)
	   {
		  timer1.Interval = 6500;
	   }
    }
}
