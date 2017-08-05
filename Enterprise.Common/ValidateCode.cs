using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Enterprise.Common
{
    public class ValidateCode
    {
        private const int ImgHeight = 26;
        private const double ImgBaseLength = 14;
        private int length;
        private static char[] constant = {
        '0','1','2','3','4','5','6','7','8','9',  'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
        /**
         * Fn: public ValidateCode()
         *
         *通过构造函数初始化
         *
         * Author: bishisan
         *
         * Date: 2017/8/5
         */

        public ValidateCode()
        {
            this.length = 4;
        }

        /**
         * Fn: public string CreateRandomCode()
         *
         * 生成随机数
         *
         * Author: bishisan
         *
         * Date: 2017/8/5
         *
         * Returns: The new random code.
         */

        public string CreateRandomCode()
        {
            StringBuilder sb = new StringBuilder();
            Random rdm = new Random();

            for (int i = 0; i < this.length; i++)
            {
                sb.Append(constant[rdm.Next(constant.Length)]);
            }
            return sb.ToString();
        }

        /**
         * Fn: public byte[] CreateImg(string code)
         *
         * 绘制验证码
         *
         * Author: bishisan
         *
         * Date: 2017/8/5
         *
         * Parameters:
         * code -  The code.
         *
         * Returns: A new array of byte.
         */

        public byte[] CreateImg(string code)
        {
            //创建位图
            Bitmap images = new Bitmap((int)Math.Ceiling((double)(code.Length * ImgBaseLength)), ImgHeight);
            //创建画布
            Graphics graphics = Graphics.FromImage(images);
            //填充颜色
            graphics.Clear(Color.White);
            //绘制边框
           // graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, images.Width - 1, images.Height - 1);

            //绘制曲线

           /* Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                int x1 = random.Next(images.Width);
                int x2 = random.Next(images.Width);
                int y1 = random.Next(images.Height);
                int y2 = random.Next(images.Height);
                graphics.DrawLine(new Pen(Color.Blue), x1, y1, x2, y2);
            }*/
            Font font = new Font("Impact", 13,FontStyle.Italic);
            //创建画笔
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, images.Width, images.Height), Color.Red, Color.Blue, 1.2f, true);

            //画入画布

            graphics.DrawString(code, font, brush, (float)4, (float)3);
            //创建字节流
            MemoryStream steam = new MemoryStream();
            //保存图片
            images.Save(steam, System.Drawing.Imaging.ImageFormat.Jpeg);
            return steam.ToArray();
        }
    }
}
