using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CT4027___Tools___Level_Editor_Project{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        private Image[,] images;
        BitmapImage texture = new BitmapImage(new Uri("pack://application:,,,/water.png"));
        string textureToUse = "Water";

        int GridWidth = 0;
        int GridHeight = 0;

        List<LevelGridData> tileDataList = new List<LevelGridData>();
        SaverLoader saver = new SaverLoader();


        public MainWindow(){
            InitializeComponent();            
            InitializeGrid();

            images = new Image[GridWidth, GridHeight];

            for (int x = 0; x < GridWidth; x++){
                for (int y = 0; y < GridHeight; y++){
                    Image image = new Image();
                    Grid.SetColumn(image, x);
                    Grid.SetRow(image, y);

                    LevelGrid.Children.Add(image);

                    images[x, y] = image;
                }
            }

            LevelGrid.MouseDown += OnMouseDown;
        }

        //Grid Creator
        public void InitializeGrid(){
            double WIDTH = this.Width;
            double HEIGHT = this.Height;

            for (int i = 0; i <= WIDTH / 32; i++){
                ColumnDefinition columnToAdd = new ColumnDefinition();
                columnToAdd.Width = new System.Windows.GridLength(32);
                LevelGrid.ColumnDefinitions.Add(columnToAdd);
                GridWidth++;
            }

            for (int i = 0; i <= HEIGHT / 32; i++){
                RowDefinition rowToAdd = new RowDefinition();
                rowToAdd.Height = new System.Windows.GridLength(32);
                LevelGrid.RowDefinitions.Add(rowToAdd);
                GridHeight++;
            }
        }

        //Click Detection For Grid
        bool penIsDown = false;
        private void OnMouseDown(object sender, MouseButtonEventArgs e){
            penIsDown = true;
            int x = (int)e.GetPosition(LevelGrid).X / 32;
            int y = (int)e.GetPosition(LevelGrid).Y / 32;

            XAxisLabel.Content = "X-axis: " + Convert.ToString(x);
            YAxisLabel.Content = "Y-axis: " + Convert.ToString(y);

            if (penIsDown){
                UseTool(x, y);
            }
        }

        //Material Implimentation
        private void UseTool(int gridX, int gridY){
            if (gridX < GridWidth && gridY < GridHeight){
                switch (selectedTool){
                    case Tool.Blank:
                        images[gridX, gridY].Source = null;
                        if (tileDataList.Exists(i => i.tileID == Convert.ToString(gridX) + "." + Convert.ToString(gridY))){
                            int indexint = tileDataList.FindIndex(i => i.tileID == Convert.ToString(gridX) + "." + Convert.ToString(gridY));
                            tileDataList.RemoveAt(indexint);
                            tileDataList.Add(new LevelGridData{
                                tileID = Convert.ToString(gridX) + "." + Convert.ToString(gridY),
                                tilePath = null,
                                tileX = gridX,
                                tileY = gridY
                            });
                        }else{
                            tileDataList.Add(new LevelGridData{
                                tileID = Convert.ToString(gridX) + "." + Convert.ToString(gridY),
                                tilePath = null,
                                tileX = gridX,
                                tileY = gridY
                            });
                        }
                        break;

                    case Tool.TextureDrawer:
                        images[gridX, gridY].Source = texture;
                        string texturePlaceHolder = Convert.ToString(texture);
                        if (tileDataList.Exists(i => i.tileID == Convert.ToString(gridX) + "." + Convert.ToString(gridY))){
                            int indexint = tileDataList.FindIndex(i => i.tileID == Convert.ToString(gridX) + "." + Convert.ToString(gridY));
                            tileDataList.RemoveAt(indexint);
                            tileDataList.Add(new LevelGridData{
                                tileID = Convert.ToString(gridX) + "." + Convert.ToString(gridY),
                                tilePath = texturePlaceHolder,
                                tileX = gridX,
                                tileY = gridY
                            });
                        }else{
                            tileDataList.Add(new LevelGridData{
                                tileID = Convert.ToString(gridX) + "." + Convert.ToString(gridY),
                                tilePath = texturePlaceHolder,
                                tileX = gridX,
                                tileY = gridY
                            });
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        //Assigns Textures and Example Image
        private void TextureAssigner(){
            switch (textureToUse){ 
                case "Blank":
                    ExampleImageHolder.Source = null;
                    break;
                case "Dirt1":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/dirt1.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/dirt1.png"));
                    break;
                case "Dirt2":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/dirt2.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/dirt2.png"));
                    break;
                case "Dirt3":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/dirt3.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/dirt3.png"));
                    break;
                case "Grass1":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/grass1.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/grass1.png"));
                    break;
                case "Grass2":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/grass2.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/grass2.png"));
                    break;
                case "Grass3":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/grass3.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/grass3.png"));
                    break;
                case "Grass4":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/grass4.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/grass4.png"));
                    break;
                case "Rock1":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/rock1.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/rock1.png"));
                    break;
                case "Rock2":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/rock2.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/rock2.png"));
                    break;
                case "Rock3":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/rock3.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/rock3.png"));
                    break;
                case "Sand":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/sand.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/sand.png"));
                    break;
                case "Water":
                    ExampleImageHolder.Source = new BitmapImage(new Uri("pack://application:,,,/water.png"));
                    texture = new BitmapImage(new Uri("pack://application:,,,/water.png"));
                    break;
                default:
                    break;
            }
        }

        //File Options
        private void NewClicked(object sender, RoutedEventArgs e){
            for (int x = 0; x < GridWidth; x++){ 
                for (int y = 0; y < GridHeight; y++){
                    images[x, y].Source = null;
                    if (tileDataList.Exists(i => i.tileID == Convert.ToString(x) + "." + Convert.ToString(y))){
                        int indexint = tileDataList.FindIndex(i => i.tileID == Convert.ToString(x) + "." + Convert.ToString(y));
                        tileDataList.RemoveAt(indexint);
                        tileDataList.Add(new LevelGridData{
                            tileID = Convert.ToString(x) + "." + Convert.ToString(y),
                            tilePath = null,
                            tileX = x,
                            tileY = y
                        });
                    }else{
                        tileDataList.Add(new LevelGridData{
                            tileID = Convert.ToString(x) + "." + Convert.ToString(y),
                            tilePath = null,
                            tileX = x,
                            tileY = y
                        });
                    }
                }
            }

        }
        private void OpenClicked(object sender, RoutedEventArgs e){
            List<LevelGridData> tileDataLoadedList = new List<LevelGridData>();
            tileDataLoadedList = saver.Load("text.json");
            for (int x = 0; x < GridWidth; x++){
                for (int y = 0; y < GridHeight; y++){
                    if (tileDataLoadedList.Exists(i => i.tileID == Convert.ToString(x) + "." + Convert.ToString(y))){
                        int indexint = tileDataLoadedList.FindIndex(i => i.tileID == Convert.ToString(x) + "." + Convert.ToString(y));
                        string ImagePath = ((LevelGridData)tileDataLoadedList[indexint]).tilePath;
                        if (ImagePath == null){
                            images[x, y].Source = null;
                        }else{
                            images[x, y].Source = new BitmapImage(new Uri(ImagePath));
                        }
                        
                    }else{
                        images[x, y].Source = null;
                    }
                }
            }


        }

        private void SaveClicked(object sender, RoutedEventArgs e){
            saver.Save(tileDataList, "text.json");          
        }
        private void ExitClicked(object sender, RoutedEventArgs e){
            Application.Current.Shutdown();
        }

        //Choose Material
        private void BlankSelected(object sender, RoutedEventArgs e){
            selectedTool = Tool.Blank;
            textureToUse = "Blank";
            TextureAssigner();
        }
        private void Dirt1Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Dirt1";
            TextureAssigner();
        }
        private void Dirt2Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Dirt2";
            TextureAssigner();
        }
        private void Dirt3Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Dirt3";
            TextureAssigner();
        }
        private void Grass1Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Grass1";
            TextureAssigner();
        }
        private void Grass2Selected(object sender, RoutedEventArgs e){ 
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Grass2";
            TextureAssigner();
        }
        private void Grass3Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Grass3";
            TextureAssigner();
        }
        private void Grass4Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Grass4";
            TextureAssigner();
        }
        private void Rock1Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Rock1";
            TextureAssigner();
        }
        private void Rock2Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Rock2";
            TextureAssigner();
        }
        private void Rock3Selected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Rock3";
            TextureAssigner();
        }
        private void SandSelected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Sand";
            TextureAssigner();
        }
        private void WaterSelected(object sender, RoutedEventArgs e){
            selectedTool = Tool.TextureDrawer;
            textureToUse = "Water";
            TextureAssigner();
        }

        //Material Enum
        public enum Tool{
            Blank,
            TextureDrawer,
        }
        private Tool selectedTool = Tool.Blank;

        //Gridlien Toggle
        private void GidLinesToggled(object sender, RoutedEventArgs e){
            if (LevelGrid.ShowGridLines == true){
                LevelGrid.ShowGridLines = false;
            }else if (LevelGrid.ShowGridLines == false){
                LevelGrid.ShowGridLines = true;
            }
        }
    }
}
