using System;
using System.Diagnostics;
using System.Collections;
namespace SpaceSim {
	public class SpaceObject {
		protected String name;
        double x;
        double y;
		protected double orbitalRadius;
		protected double orbitalPeriod;
		protected double objectRadius;
		protected double rotationalPeriod;
		protected String objectColor;
		protected SpaceObject rotatingAround;
        protected ArrayList childs;

		public SpaceObject(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) {
			name = _name;
			orbitalRadius = _orbitalRadius;
			orbitalPeriod = _orbitalPeriod;
			objectRadius = _objectRadius;
			rotationalPeriod = _rotationalPeriod;
			objectColor = _objectColor;
            childs = new ArrayList();
		}
        public override string ToString() {
            return name;
        }
		public virtual void Draw() {
		Console.WriteLine(name);
		}
		public SpaceObject getRotatingAround(){
			return rotatingAround;
		}
        public void addParent(SpaceObject a1)
        {
            rotatingAround = a1;
        }
        public SpaceObject getParent()
        {
            return rotatingAround;
        }
        public void addChild(SpaceObject a1)
        {
            childs.Add(a1);
        }
        public ArrayList getChild()
        {
            return childs;
        }
		public String getName(){
			return name;
		}
		public double getOrbitalRadius(){
			return orbitalRadius;
		}
		public double getOrbitalPeriod(){
			return orbitalPeriod;
		}
        public double getX()
        {
            return x;
        }
        public double getY()
        {
            return y;
        }
        public void calculateXY(double days, double xT, double yT)
        {
            if (name == "Sun")
            {
                x = 0;
                y = 0;
                for (int i = 0; i < childs.Count; i++)
                {
                    SpaceObject tObj = (SpaceObject)(childs[i]);
                    tObj.calculateXY(days, x, y);
                }
            }
            else
            {
                x = 0;
                y = 0;
                double distance;
                double totalTime;
                double x2 = 0;
                double y2 = 0;
                distance = this.getOrbitalRadius();
                totalTime = this.getOrbitalPeriod();

                double degrees = 360 / totalTime * days;
                x2 = Math.Cos((Math.PI / 180) * degrees) * distance;
                y2 = Math.Sin((Math.PI / 180) * degrees) * distance;
                x = x2;
                y = y2;
                x += xT;
                y += yT;
                for (int i = 0; i < childs.Count; i++)
                {
                    SpaceObject tObj = (SpaceObject)(childs[i]);
                    tObj.calculateXY(days, x, y);
                }
            }

        }
		public double getObjectRadius(){
			return objectRadius;
		}
		public double getRotationalPeriod(){
			return rotationalPeriod;
		}
		public String getColor(){
			return objectColor;
		}
	}
	public class Star : SpaceObject {
        public Star(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Star : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
	public class Planet : SpaceObject {
        public Planet(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Planet : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
	public class Moon : SpaceObject {
        public Moon(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Moon : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
	public class Comets : SpaceObject {
        public Comets(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Comets : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
	public class Asteroids : SpaceObject {
        public Asteroids(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Asteroids : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
	public class Asteroid_Belts : SpaceObject {
        public Asteroid_Belts(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Asteroid Belts : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
	public class Dwarf_Planets : SpaceObject {
        public Dwarf_Planets(String _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, String _objectColor) : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
		public override void Draw() {
			Console.Write("Dwarf planets : " + orbitalRadius + " : " + orbitalPeriod + " : " + objectRadius + " : " + rotationalPeriod + " : " + objectColor + " : ");
			base.Draw();
		}
	}
}