   M S B A M L   `   `   `  ????`  \CT4027 - Tools - Level Editor Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CT4027___Tools___Level_Editor_Project%CT4027___Tools___Level_Editor_Project  5   	   6    0CT4027___Tools___Level_Editor_Project.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:CT4027___Tools___Level_Editor_Project     5   	     ? Title$  Level Editor??5   	   $	??450??6   $	??800??6+   .??5	      ]? .+?5
   
   o? $	??Top=?6   
???????.@?5      m? $
??File??6   .@?5      m? -   5        $	??New??5      6=   m? 5      -   5        $
??Open??5      6?   m? 5      -   5        $
??Save??5      6?   m? 5      -   5        $
??Exit??5      6?   5      ?? 5      -   5         ??Name$ TextureComboBox??5       ?? 
IsEditable .  ?? 
IsReadOnly .  ?? Text$ Select Texture??6T   $	??150??6j   .@?5      ?? -   5        .??5   8   Blank6?   ?? 5      -   5        .??5   8   	Dirt #16A   ?? 5      -   5        .??5   8   	Dirt #26A   ?? 5      -	   5        .??5   8   	Dirt #36A   ?? 5      -
   5        .??5   9   
Grass #16C   ?? 5      -   5        .??5   9   
Grass #26C   ?? 5      -   5        .??5   9   
Grass #36C   ?? 5      -   5        .??5   9   
Grass #46C   ?? 5      -   5        .??5   8   	Rock #16A   ?? 5      -   5        .??5   8   	Rock #26A   ?? 5      -   5        .??5   8   Rock#36@   ?? 5      -   5        .??5   7   Sand6=   ?? 5      -   5        .??5   8   Water6?   5      ? 5       -   5         ?Name$ ExampleGrid??5       
???OO/? ? ColumnDefinitions 5!      ?? 5"      $??32 ?6'   64    ? RowDefinitions 5$      ?? 5%      $??32 ?6$   62   .+?5'      ?? -   5         ??Name$ ExampleImageHolder??5'      66   5(      ?? 5)      $??Coordinates:??6   6-   ?? 5*      -   5        	 ??Name$	 
XAxisLabel??5*      $??X-axis: ??6(   $	??100??6;   6I   ?? 5+      -   5        $	 
YAxisLabel??5+      $??Y-axis: ??6(   $	??100??6;   6I   ?? 5,      -   5        
 ??Name$
 ToggleGridLine??5,      $??Toggle Gridlines??6-   $	??100??6H   6n   5-      ? 5.   
   -   5        $ 	LevelGrid??5.      
??????? 5/       51      52      53      54      