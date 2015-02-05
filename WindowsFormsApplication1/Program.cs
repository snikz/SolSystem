using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using SpaceSim;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            

            //Orbital radius (assume circular orbits for simplicity), orbital
            //period, object radius, rotational period (length of a day) and object color. 
            ArrayList a = new ArrayList();
            
            a.Add(new Star("Sun", 0, 0, 695500, 0, "Yellow"));
            SpaceObject t1 = (SpaceObject)(a[0]);
            t1.addParent(t1);
            a.Add(new Planet("Mercury", 57910000, 88, 2440, 59, "White"));
            a.Add(new Planet("Venus", 108200000, 224, 5041.5, 243, "Beige"));
            a.Add(new Planet("Earth", 149600000, 365, 6378, 1, "Blue"));
            a.Add(new Planet("Mars", 227940000, 687, 3397, 1.03, "Red"));
            a.Add(new Planet("Jupiter", 778330000, 4328, 71492, 0.41, "Yellow"));
            a.Add(new Planet("Saturn", 1429400000, 10752, 60268, 0.425, "Blue"));
            a.Add(new Planet("Uranus", 2870990000, 30685, 25559, 0.74, "Blue"));
            a.Add(new Planet("Neptune", 4504000000, 60152, 24766, 0.79, "Blue"));
            a.Add(new Planet("Pluto", 5913520000, 90410, 1137, 6.39, "Grey"));
            for (int i = 1; i < 10; i++)
            {
                SpaceObject t2 = (SpaceObject)(a[i]);
                t1.addChild(t2);
                t2.addParent(t1);
            }


            a.Add(new Moon("Phobos", 9000, 0.32, 11, 0, "Grey"));
            a.Add(new Moon("Deimos", 23000, 1.26, 6.3, 0, "Grey"));
            for (int i = 10; i < 12; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[4]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }

            a.Add(new Moon("Metis", 128000, 0.29, 20, 0, "Grey"));
            a.Add(new Moon("Adrastea", 129000, 0.30, 10, 0, "Grey"));
            a.Add(new Moon("Amalthea", 181000, 0.50, 94, 0, "Grey"));
            a.Add(new Moon("Thebe", 222000, 0.67, 50, 0, "Grey"));
            a.Add(new Moon("Io", 422000, 1.77, 1815, 0, "Metalic"));
            a.Add(new Moon("Europa", 671000, 3.55, 1569, 0, "Red/grey"));
            a.Add(new Moon("Ganymede", 1070000, 7.15, 2631, 0, "Grey"));
            a.Add(new Moon("Callisto", 1883000, 16.69, 2400, 0, "Grey"));
            a.Add(new Moon("Leda", 11094000, 238.72, 8, 0, "Grey"));
            a.Add(new Moon("Himalia", 11480000, 250.57, 93, 0, "Grey"));
            a.Add(new Moon("Lysithea", 11720000, 259.22, 19, 0, "Grey"));
            a.Add(new Moon("Elara", 11737000, 259.65, 38, 0, "Grey"));
            a.Add(new Moon("Ananke", 21200000, -631, 16, 0, "Grey"));
            a.Add(new Moon("Carme", 22600000, -692, 20, 0, "Grey"));
            a.Add(new Moon("Pasiphae", 23500000, -735, 25, 0, "Grey"));
            a.Add(new Moon("Sinope", 23700000, -758, 18, 0, "Grey"));
            for (int i = 12; i < 28; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[5]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }

            a.Add(new Moon("Pan", 134000, 0.58, 10, 0, "Grey"));
            a.Add(new Moon("Atlas", 138000, 0.60, 15, 0, "Grey"));
            a.Add(new Moon("Prometheus", 139000, 0.61, 45.5, 0, "Grey"));
            a.Add(new Moon("Pandora", 142000, 0.63, 42, 0, "Grey"));
            a.Add(new Moon("Epimetheus", 151000, 0.69, 57.5, 0, "Grey"));
            a.Add(new Moon("Janus", 151000, 0.69, 89, 0, "Grey"));
            a.Add(new Moon("Mimas", 186000, 0.94, 196, 0, "Grey"));
            a.Add(new Moon("Enceladus", 238000, 13516, 249, 0, "Grey"));
            a.Add(new Moon("Tethys", 295000, 32509, 530, 0, "Grey"));
            a.Add(new Moon("Telesto", 295000, 32509, 14.5, 0, "Grey"));
            a.Add(new Moon("Calypso", 295000, 32509, 13, 0, "Grey"));
            a.Add(new Moon("Dione", 377000, 27061, 560, 0, "Grey"));
            a.Add(new Moon("Helene", 377000, 27061, 16.5, 0, "Grey"));
            a.Add(new Moon("Rhea", 527000, 19085, 765, 0, "Grey"));
            a.Add(new Moon("Titan", 1222000, 15.95, 2575, 0, "Grey"));
            a.Add(new Moon("Hyperion", 1481000, 21.28, 143, 0, "Grey"));
            a.Add(new Moon("Iapetus", 3561000, 79.33, 730, 0, "Grey"));
            a.Add(new Moon("Phoebe", 12952000, -550.48, 110, 0, "Grey"));
            for (int i = 28; i < 46; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[6]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }

            a.Add(new Moon("Cordelia", 50000, 0.34, 13, 0, "Grey"));
            a.Add(new Moon("Ophelia", 54000, 0.38, 16, 0, "Grey"));
            a.Add(new Moon("Bianca", 59000, 0.43, 22, 0, "Grey"));
            a.Add(new Moon("Cressida", 62000, 0.46, 33, 0, "Grey"));
            a.Add(new Moon("Desdemona", 63000, 0.47, 29, 0, "Grey"));
            a.Add(new Moon("Juliet", 64000, 0.49, 42, 0, "Grey"));
            a.Add(new Moon("Portia", 66000, 0.51, 55, 0, "Grey"));
            a.Add(new Moon("Rosalind", 70000, 0.56, 27, 0, "Grey"));
            a.Add(new Moon("Belinda", 75000, 0.62, 34, 0, "Grey"));
            a.Add(new Moon("Puck", 86000, 0.76, 77, 0, "Grey"));
            a.Add(new Moon("Miranda", 130000, 14977, 236, 0, "Grey"));
            a.Add(new Moon("Ariel", 191000, 19025, 579, 0, "Grey"));
            a.Add(new Moon("Umbriel", 266000, 41730, 585, 0, "Grey"));
            a.Add(new Moon("Titania", 436000, 26146, 789, 0, "Grey"));
            a.Add(new Moon("Oberon", 583000, 13.46, 761.5, 0, "Grey"));
            a.Add(new Moon("Caliban", 7169000, -580, 40, 0, "Grey"));
            a.Add(new Moon("Stephano", 7948000, -674, 20, 0, "Grey"));
            a.Add(new Moon("Sycorax", 12213000, -1289, 80, 0, "Grey"));
            a.Add(new Moon("Prospero", 16568000, -2019, 20, 0, "Grey"));
            a.Add(new Moon("Setebos", 17681000, -2239, 20, 0, "Grey"));
            for (int i = 46; i < 66; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[7]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }

            a.Add(new Moon("Naiad", 48000, 0.29, 29, 0, "Grey"));
            a.Add(new Moon("Thalassa", 50000, 0.31, 40, 0, "Grey"));
            a.Add(new Moon("Despina", 53000, 0.33, 74, 0, "Grey"));
            a.Add(new Moon("Galatea", 62000, 0.43, 79, 0, "Grey"));
            a.Add(new Moon("Larissa", 74000, 0.55, 96.5, 0, "Grey"));
            a.Add(new Moon("Proteus", 118000, 42339, 209, 0, "Grey"));
            a.Add(new Moon("Triton", 355000, -5.88, 1350, 0, "Grey"));
            a.Add(new Moon("Nereid", 5513000, 360.13, 170, 0, "Grey"));
            for (int i = 66; i < 74; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[8]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }

            a.Add(new Moon("Charo", 20000, 6.39, 603, 0, "Grey"));
            a.Add(new Moon("Nix", 49000, 24.86, 1137, 0, "Grey"));
            a.Add(new Moon("Hydra", 65000, 38.21, 1137, 0, "Grey"));
            for (int i = 74; i < 77; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[9]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }
            a.Add(new Moon("Moon", 384400, 27, 1738, 27, "Grey"));
            for (int i = 77; i < 78; i++)
            {
                SpaceObject tPlan = (SpaceObject)(a[3]);
                SpaceObject t2 = (SpaceObject)(a[i]);
                tPlan.addChild(t2);
                t2.addParent(tPlan);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(a));
        }
        
    }
}
