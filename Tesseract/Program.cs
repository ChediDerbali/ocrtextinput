using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;







namespace Tesseract.ConsoleDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var testImagePath = @"D:\the smallest dataset\001.png";
            var testfolderpath = @"D:\doc preprocessing\Tesseract\Tesseract\testresults\";
            if (args.Length > 0)
            {
                testImagePath = args[0];
            }
            //OcrResult(testImagePath);
            OcrTextDataInput(@"D:\the smallest dataset\", "TN81 MARSH TUNISIA AV N°47241 MALADIE Q4.2020-2", "png");
            //Binarization(testImagePath, testfolderpath);
            //Console.Write(OcrResult(testImagePath));
            Console.ReadKey(true);
        }



        public static void Binarization(string src, string dest)
        {
            Mat srcImg = CvInvoke.Imread(src); //Read the picture
            UMat grayscaled = new UMat();
            CvInvoke.CvtColor(srcImg, grayscaled, ColorConversion.Rgba2Gray); //grayscale
            CvInvoke.Imwrite(dest + "Gray.jpg", grayscaled); //Save the result picture
            UMat dst2 = new UMat();



            #region Resize
            CvInvoke.Resize(grayscaled, dst2, new Size(), 3, 3, Inter.Area);
            CvInvoke.Imwrite(dest + @"resize3\" + "Area.jpg", dst2); //Save the result picture

            CvInvoke.Resize(grayscaled, dst2, new Size(), 3, 3, Inter.Cubic);
            CvInvoke.Imwrite(dest + @"resize3\" + "Cubic.jpg", dst2); //Save the result picture

            CvInvoke.Resize(grayscaled, dst2, new Size(), 3, 3, Inter.Lanczos4);
            CvInvoke.Imwrite(dest + @"resize3\" + "Lanczos4.jpg", dst2); //Save the result picture

            CvInvoke.Resize(grayscaled, dst2, new Size(), 3, 3, Inter.Linear);
            CvInvoke.Imwrite(dest + @"resize3\" + "Linear.jpg", dst2); //Save the result picture

            CvInvoke.Resize(grayscaled, dst2, new Size(), 3, 3, Inter.LinearExact);
            CvInvoke.Imwrite(dest + @"resize3\" + "LinearExact.jpg", dst2); //Save the result picture

            CvInvoke.Resize(grayscaled, dst2, new Size(), 3, 3, Inter.Nearest);
            CvInvoke.Imwrite(dest + @"resize3\" + "Nearest.jpg", dst2); //Save the result picture

            #endregion

            #region binary
            //for (var i = 0; i < 255; i += 10)
            //{
            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.Binary);
            //    CvInvoke.Imwrite(dest + @"onlyBin\Binary\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.BinaryInv);
            //    CvInvoke.Imwrite(dest + @"onlyBin\BinaryInv\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.Mask);
            //    CvInvoke.Imwrite(dest + @"onlyBin\Mask\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.Otsu);
            //    CvInvoke.Imwrite(dest + @"onlyBin\Otsu\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.ToZero);
            //    CvInvoke.Imwrite(dest + @"onlyBin\ToZero\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.ToZeroInv);
            //    CvInvoke.Imwrite(dest + @"onlyBin\ToZeroInv\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.Triangle);
            //    CvInvoke.Imwrite(dest + @"onlyBin\Triangle\" + i + ".png", dst2); //Save the result picture

            //    CvInvoke.Threshold(grayscaled, dst2, i, 255, ThresholdType.Trunc);
            //    CvInvoke.Imwrite(dest + @"onlyBin\Trunc\" + i + ".png", dst2); //Save the result picture

            //}
            #endregion

            #region brightness
            //for (int i=0; i<=30; i++)
            //{
            //    Mat equa = srcImg * (i / 10.0);
            //    CvInvoke.Imwrite(dest + @"brightness\"+i/10.0+".png", equa);
            //}
            #endregion

            //CvInvoke.EqualizeHist(srcImg, equa);
            //CvInvoke.Imwrite(dest + "equalized.jpg", equa); //Save the result picture

            //CvInvoke.EqualizeHist(grayscaled, equa);
            #region addition
            //for (int i = 0; i <= 250; i+=5)
            //{
            //    Mat equa = srcImg + (i);
            //    CvInvoke.Imwrite(dest + @"addition\" + i + ".png", equa);
            //}
            #endregion

            #region adaptiveThresholding
            //int neighborhood = 3;
            //for (var i = 3;  i < 25; i += 2)
            //{
            //    CvInvoke.AdaptiveThreshold(grayscaled, dst2, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, i, 3);
            //    CvInvoke.Imwrite(dest + @"adaptiveBin\GaussianC\Binary\" + 255 + " " + i + ".png", dst2); //Save the result picture

            //    CvInvoke.AdaptiveThreshold(grayscaled, dst2, 255, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, i, 3);
            //    CvInvoke.Imwrite(dest + @"adaptiveBin\GaussianC\BinaryInv\" + 255 + " "+ i + ".png", dst2); //Save the result picture

            //    CvInvoke.AdaptiveThreshold(grayscaled, dst2, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, i, 3);
            //    CvInvoke.Imwrite(dest + @"adaptiveBin\MeanC\Binary\" + 255 + " " + i + ".png", dst2); //Save the result picture

            //    CvInvoke.AdaptiveThreshold(grayscaled, dst2, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, i, 3);
            //    CvInvoke.Imwrite(dest + @"adaptiveBin\MeanC\BinaryInv\" + 255 + " " + i + ".png", dst2); //Save the result picture

            //}
            #endregion

            #region Sobel
            //CvInvoke.Sobel(srcImg, dst2, DepthType.Cv8U, 0, 1);
            //CvInvoke.Imwrite(dest + "sobelInv8U.jpg", dst2); //Save the result picture
            #endregion


            #region tessetact
            /*using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
             {
                 using (var img = Pix.LoadFromFile(src))
                 {
                     var imint = img.ConvertRGBToGray();
                     imint.Save(dest + "gray.png", ImageFormat.Png);

                     var imout = imint.BinarizeSauvola(2, 0, true);
                     imout.Save(dest + "Sauvogray.png", ImageFormat.Png);



                     var imintr = img.ConvertRGBToGray(0f, 0.5f, 0.5f);
                     imint.Save(dest + "R-1.png", ImageFormat.Png);

                     imout = imintr.BinarizeSauvola(2, 0, true);
                     imout.Save(dest + "SauvoR-1.png", ImageFormat.Png);



                     var imintg = img.ConvertRGBToGray(0.5f, 0f, 0.5f);
                     imint.Save(dest + "G-1.png", ImageFormat.Png);

                     imout = imintg.BinarizeSauvola(2, 0, true);
                     imout.Save(dest + "SauvoG-1.png", ImageFormat.Png);



                     var imintb = img.ConvertRGBToGray(0.5f, 0.5f, 0f);
                     imint.Save(dest + "B-1.png", ImageFormat.Png);

                     imout = imintb.BinarizeSauvola(2, 0, true);
                     imout.Save(dest + "SauvoB-1.png", ImageFormat.Png);


                      for (int i = 0; i < 51; i++)
                      {
            var imout = imint.BinarizeSauvola(2, 0, true);


            imout.Save(dest + "Sauvo.png", ImageFormat.Png);

                imout = imint.BinarizeSauvola(2, 0, true);
                imout.Save(dest + i + "B2.png", ImageFormat.Png);

                imout = imout.BinarizeOtsuAdaptiveThreshold(imint.Width, imint.Height, 0, 0, 0);
                imout.Save(dest + i + ".png", ImageFormat.Png);
        }
    }
}*/
            #endregion
        }


        public static string OcrResult(string testImagePath)
        {
            var json = "";
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            Rect region = page.RegionOfInterest;
                            Block result = new Block(region);
                            result.Type = "Page";
                            result.Text = page.GetText();
                            result.Children = new List<Block>();
                            result.Confidence = page.GetMeanConfidence();
                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();
                                do
                                {
                                    Rect recttt = new Rect();
                                    iter.TryGetBoundingBox(PageIteratorLevel.Block, out recttt);
                                    Block block = new Block(recttt);
                                    block.Type = "Block";
                                    block.Text = iter.GetText(PageIteratorLevel.Block);
                                    block.Children = new List<Block>();
                                    block.Confidence = iter.GetConfidence(PageIteratorLevel.Block);

                                    do
                                    {
                                        iter.TryGetBoundingBox(PageIteratorLevel.Para, out recttt);
                                        Block paragraph = new Block(recttt);
                                        paragraph.Type = "Paragraph";
                                        paragraph.Text = iter.GetText(PageIteratorLevel.Para);
                                        paragraph.Children = new List<Block>();
                                        paragraph.Confidence = iter.GetConfidence(PageIteratorLevel.Para);
                                        do
                                        {
                                            iter.TryGetBoundingBox(PageIteratorLevel.TextLine, out recttt);
                                            Block textLine = new Block(recttt);
                                            textLine.Type = "text Line";
                                            textLine.Text = iter.GetText(PageIteratorLevel.TextLine);
                                            textLine.Children = new List<Block>();
                                            textLine.Confidence = iter.GetConfidence(PageIteratorLevel.TextLine);


                                            do
                                            {
                                                iter.TryGetBoundingBox(PageIteratorLevel.Word, out recttt);
                                                Block word = new Block(recttt);
                                                word.Type = "word";
                                                word.Text = iter.GetText(PageIteratorLevel.Word);
                                                word.Confidence = iter.GetConfidence(PageIteratorLevel.Word);
                                                textLine.Children.Add(word);


                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                                            paragraph.Children.Add(textLine);

                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                        block.Children.Add(paragraph);
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                    result.Children.Add(block);
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                            Console.WriteLine(result.Confidence);
                            json = JsonSerializer.Serialize(result);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }

            return json;
        }

        public static void OcrTextDataInput(string testImagePath,string testImageFileName, string fileFormat)
        {
            var json = "";
            try
            {
                using (StreamWriter writer = new StreamWriter(testImagePath + testImageFileName + ".txt"))
                {

                    using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                    {
                        using (var img = Pix.LoadFromFile(testImagePath + testImageFileName + "." + fileFormat))
                        {
                            using (var page = engine.Process(img))
                            {
                                using (var iter = page.GetIterator())
                                {
                                    iter.Begin();
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                Rect recttt = new Rect();
                                                iter.TryGetBoundingBox(PageIteratorLevel.TextLine, out recttt);
                                                if (iter.GetText(PageIteratorLevel.TextLine).Trim() != "")
                                                {
                                                    Console.WriteLine(recttt.X1 + "," + recttt.Y1 + "," +
                                                        recttt.X2 + "," + recttt.Y1 + "," +
                                                        recttt.X2 + "," + recttt.Y2 + "," +
                                                        recttt.X1 + "," + recttt.Y2 + "," +
                                                        iter.GetText(PageIteratorLevel.TextLine).Trim());
                                                    writer.WriteLine(recttt.X1 + "," + recttt.Y1 + "," +
                                                        recttt.X2 + "," + recttt.Y1 + "," +
                                                        recttt.X2 + "," + recttt.Y2 + "," +
                                                        recttt.X1 + "," + recttt.Y2 + "," +
                                                        iter.GetText(PageIteratorLevel.TextLine).Trim());
                                                }
                                            } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                        } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                    } while (iter.Next(PageIteratorLevel.Block));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
            }
        }
    }
}
