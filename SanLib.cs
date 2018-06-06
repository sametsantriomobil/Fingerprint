using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace SanLib
{
    class Background
    {
        public void ShowMessageBox(String mesaj, String title = "Result")
        {
            var thread = new Thread(
             () =>
             {
                 MessageBox.Show(mesaj, title);
             });
            thread.Start();
        }
    }

    public class Location
    {
        public Double real_x=0.0d, real_y=0.0d;
        public Int32 map_x=0, map_y=0;
        public Int32 image_x=0, image_y=0;
        public Int32 scale=1;
        public Int32 width=0, height=0;

        public Location(Int32 w, Int32 h, Int32 s)
        {
            scale = s;
            width = w;
            height = h;

        }

        public void fromReal(Double x, Double y)
        {

            real_x = x;
            real_y = y;

            map_x = Convert.ToInt32(scale * real_x);
            map_y = Convert.ToInt32(scale * real_y);

            image_x = map_x;
            image_y = height - map_y;


        }

        public void fromMap(Int32 x, Int32 y)
        {
            map_x = x;
            map_y = y;

            image_x = map_x;
            image_y = height - map_y;

            real_x = (double)map_x / scale;
            real_y = (double)map_x / scale;

        }

        public void fromImage(Int32 x, Int32 y)
        {

            image_x = x;
            image_y = y;

            map_x = image_x;
            map_y = height - image_y;

            real_x = (double)map_x / scale;
            real_y = (double)map_y / scale;

          
        }
    }

}
