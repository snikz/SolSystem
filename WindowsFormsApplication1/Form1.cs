using System;
using SpaceSim;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        Class1 timerEvent;
        int zoom;
        ArrayList a;
        int days;
        int mySeconds;
        int countedDays;
        bool moving = false;
        ArrayList labelList;
        Label Label1;
        String selectedObject;
        bool removeLabel = false;
        public Form1(ArrayList a)
        {
            this.a = a;
            days = 0;
            zoom = 330;
            mySeconds = 20;
            countedDays = 0;
            labelList = new ArrayList();

            timerEvent = new Class1();
            timerEvent.evl += new DoWhenTick(onTick);
            timerEvent.init(mySeconds);

            WindowState = FormWindowState.Maximized;

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = a;
            SpaceObject sun = (SpaceObject)(a[0]);
            sun.calculateXY(countedDays, 0, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            removeLabel = true;
            countedDays = 0;
            moving = true;
            try
            {
                days = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException e1)
            {
                textBox1.Text = "";
                System.Windows.Forms.MessageBox.Show("Input is not a valid number(int)");
            }
            catch (OverflowException e1)
            {
                System.Windows.Forms.MessageBox.Show("This number doesn't fit in Int32");
                textBox1.Text = "";
            }
            if (!checkBox2.Checked)
            {
                timerEvent.start(Convert.ToInt32(days), false);
                countedDays = days;
                removeLabel = true;
                removeLabels();
            }
            else if (checkBox2.Checked)
            {
                timerEvent.start(Convert.ToInt32(days), true);
            }
            removeLabels();
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            int x = 650;
            int y = 350;
            //if (!moving)
            //{
                for (int i = 0; i < a.Count; i++)
                {
                    SpaceObject t1 = (SpaceObject)(a[i]);

                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    System.Drawing.SolidBrush myBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                    System.Drawing.Graphics formGraphics;
                    formGraphics = CreateGraphics();
                    double distX = t1.getX();
                    double distY = t1.getY();

                    distX /= 10000000;
                    distX += x;
                    distY /= 10000000;
                    distY += y;

                    int drawX = Convert.ToInt32(distX);
                    int drawY = Convert.ToInt32(distY);

                    if (t1.getName() == selectedObject)
                    {
                        int deriveBy = 10000000;
                        formGraphics.FillEllipse(myBrush, new Rectangle((x - 2), (y - 2), 10, 10));

                        if (checkBox1.Checked && !moving)
                        {
                            Label1 = new Label();
                            Label1.Location = new Point(x, (y + 10));
                            Label1.Text = t1.getName();
                            Label1.Width = 50;
                            Label1.Height = 12;
                            try
                            {
                                Controls.Add(Label1);
                                labelList.Add(Label1);
                                Debug.Print("name not shwon on center");
                            }
                            catch (Win32Exception e1)
                            {
                            }
                        }

                        ArrayList temp = t1.getChild();
                        if (temp.Count > 0)
                        {
                            SpaceObject temp1 = (SpaceObject)(temp[(temp.Count - 1)]);
                            double tempDerived = (temp1.getOrbitalRadius());
                            tempDerived /= zoom;
                            deriveBy = Convert.ToInt32(tempDerived);
                        }
                        for (int j = 0; j < temp.Count; j++)
                        {
                            SpaceObject t2 = (SpaceObject)(temp[j]);

                            double childX = t2.getX();
                            double childY = t2.getY();
                            childX -= t2.getParent().getX();
                            childY -= t2.getParent().getY();


                            childX /= deriveBy;
                            childX += x;
                            childY /= deriveBy;
                            childY += y;

                            int drawXchild = Convert.ToInt32(childX);
                            int drawYchild = Convert.ToInt32(childY);


                            formGraphics.FillEllipse(myBrush2, new Rectangle(drawXchild, drawYchild, 6, 6));
                            if (checkBox1.Checked && !moving)
                            {
                                Label1 = new Label();
                                Label1.Location = new Point(drawXchild, (drawYchild + 5));
                                String test = "";
                                try
                                {

                                    test = t2.getName();// +"\r\n" + xForOutput + "\r\n" + yForOutput;
                                }
                                catch (FormatException e1)
                                {
                                    test = t2.getName();// + "\r\n" + t2.getOrbitalRadius() + "\r\n" + "0";

                                }
                                catch (OverflowException e1)
                                {
                                    test = t2.getName();// +"\r\n" + t2.getOrbitalRadius() + "\r\n" + "0";

                                }
                                Label1.Text = test;
                                Label1.Height = 12;
                                Label1.Width = 50;
                                try
                                {
                                    Controls.Add(Label1);
                                    labelList.Add(Label1);
                                }
                                catch (Win32Exception e1)
                                {

                                }
                            }
                        }
                        break;
                    }

                    myBrush.Dispose();
                    myBrush2.Dispose();
                    formGraphics.Dispose();
               // }
            }
            base.OnPaint(e);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t12 = 2;
            removeLabel = true;
            removeLabels();
            Object temp = comboBox1.SelectedItem;
            SpaceObject t1 = null;
            for (int i = 0; i < a.Count; i++)
            {
                t1 = (SpaceObject)(a[i]);
                if (t1.getName() == temp.ToString())
                    break;
            }
            string output = String.Format("OrbitalRadius {0}\r\nOrbitalPeriod {1}\r\nObjectradius {2}\r\nRotationalPeriod{3}\r\nObject color{4}\r\nRotating around {5}\r\nNumber of moons/planets {6}", t1.getOrbitalRadius(), t1.getOrbitalPeriod(), t1.getObjectRadius(), t1.getRotationalPeriod(), t1.getColor(), t1.getRotatingAround().getName(), t1.getChild().Count);
            label1.Text = output;
            selectedObject = temp.ToString();

            this.Invalidate();
        }
        private void removeLabels()
        {
            removeLabel = false;
            for (int i = 0; i < labelList.Count; i++)
            {
                Label1 = (Label)(labelList[i]);
                try
                {
                    this.Controls.Remove(Label1);
                }
                catch (InvalidOperationException e1)
                {

                }
            }
        }
        private void onTick(int s1)
        {
            countedDays = s1;
            SpaceObject sun = (SpaceObject)(a[0]);
            sun.calculateXY(countedDays, 0, 0);
            if (countedDays < days)
            {
                Debug.Print(s1.ToString());
                Debug.Print(days.ToString());
                this.countedDays = s1;
            }
            else
            {
                Debug.Print("Removing labels in tick");
                timerEvent.stop();
                moving = false;
                removeLabels();
            }
            if (removeLabel)
            {
                removeLabels();
            }
            this.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            removeLabel = true;

            removeLabels();
            try
            {
                zoom = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException e1)
            {
                System.Windows.Forms.MessageBox.Show("Input is not a valid number(int).");
                textBox2.Text = "";
            }
            catch (OverflowException e1)
            {
                System.Windows.Forms.MessageBox.Show("This number doesn't fit in Int32");
                textBox2.Text = "";
            }
            this.Invalidate();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            removeLabel = true;
            removeLabels();
            this.Invalidate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            removeLabel = true;
            removeLabels();
            try
            {
                mySeconds = Convert.ToInt32(textBox3.Text);
                timerEvent.setTimer(mySeconds);
            }
            catch (FormatException e1)
            {
                System.Windows.Forms.MessageBox.Show("Input is not a valid number(int).");
                textBox3.Text = "";
            }
            catch (OverflowException e1)
            {
                textBox3.Text = "";
                System.Windows.Forms.MessageBox.Show("This number doesn't fit in Int32");
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            removeLabel = true;
            removeLabels();
            if (!checkBox2.Checked)
            {
                countedDays = days;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            removeLabel = true;
            removeLabels();
            if (!moving)
            {
                if (e.Button == MouseButtons.Right)
                {
                    Object temp = comboBox1.SelectedItem;
                    String prev = "";
                    for (int i = 0; i < a.Count; i++)
                    {
                        SpaceObject obj = (SpaceObject)(a[i]);
                        if (temp.ToString() == obj.getName())
                            prev = obj.getParent().getName();
                    }
                    comboBox1.SelectedIndex = comboBox1.FindStringExact(prev);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    int xPos = MousePosition.X;
                    int yPos = MousePosition.Y;
                    int x = 650;
                    int y = 350;
                    Object temp = comboBox1.SelectedItem;
                    String name = temp.ToString();
                    for (int i = 0; i < a.Count; i++)
                    {
                        SpaceObject obj = (SpaceObject)(a[i]);
                        if (obj.getName() == name)
                        {
                            double distX = obj.getX();
                            double distY = obj.getY();

                            distX /= 10000000;
                            distX += x;
                            distY /= 10000000;
                            distY += y;

                            int drawX = Convert.ToInt32(distX);
                            int drawY = Convert.ToInt32(distY);
                            ArrayList temp1 = obj.getChild();
                            int deriveBy = 10000000;
                            if (temp1.Count > 0)
                            {
                                SpaceObject temp2 = (SpaceObject)(temp1[(temp1.Count - 1)]);
                                double tempDerived = (temp2.getOrbitalRadius());
                                tempDerived /= zoom;
                                deriveBy = Convert.ToInt32(tempDerived);
                            }
                            for (int j = 0; j < obj.getChild().Count; j++)
                            {
                                SpaceObject t2 = (SpaceObject)(temp1[j]);

                                double childX = t2.getX();
                                double childY = t2.getY();
                                childX -= t2.getParent().getX();
                                childY -= t2.getParent().getY();

                                childX /= deriveBy;
                                childX += x;
                                childY /= deriveBy;
                                childY += y;

                                int drawXchild = Convert.ToInt32(childX);
                                int drawYchild = Convert.ToInt32(childY);

                                if (xPos >= drawXchild && xPos <= (drawXchild + 5))
                                    comboBox1.SelectedIndex = comboBox1.FindStringExact(t2.getName());
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
