   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	       Presentation.Сhoose   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	     � Title$  Choose��5      $	��720��6)   $
��1280��66    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$ False��6.    � 	Resources 5
         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth   Opacity   
BlurRadius��%  &	        �� 5   
   " ��6$   .�5      ��  � ��$ 19(�6)   �� 5       � ��$ Roboto)�6+   �� 5       � �� �#1414146+   �� 5       � ��$	 245��6&   �� 5       � ��$ 55��6'   �� 5       � ��$ 	10 0 10 0q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ ButtonBorder��6!   ���#FFF���#4E7E13$	��2.2q�6_   $	 8��6u   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $ ButtonBorder��6)    � �� �#4E7E136Y   5      5       5"      �� 5$       �@J�Effect 5%        5&      $ #333333��6'   $	 300Q�67   $ 5Q�6G   $	 0.3Q�6W   $ 10Q�6e   5(      5)      5*      .��5,      � .+�5-   
   �� ���#141414$��3��6#   �� 5.   
   ���#4E7E13$	��360��6#   $	��Top=�60   $��3��6H   �� 51   
   ��52      �� 53       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��54      �  � Color$ #006600��6#    � Offset$ 0Q�63   � 55      $ Black��6#   $ 1Q�61   56      58      �� 5;   
   ���#FCFBFB �� Padding$ 30q�6&   $	 100 0 0 100��63   $��Right=�6N   $
��1000��6j   $��0,0,0,0q�6w   ._�5=      ��  �� Orientation$ Vertical=�6   $��Center=�60   $��Center=�6M   .+�5@      �� $��Choose��6   $��28(�6*   $��Center=�68   $��Verdana)�6U   ���#141414$��0 0 0 25q�6   �� 5C      $ 
Horizontal=�6   .+�5F      �� -   5         ��Name$ CommanderButton��5F      $��I'm a Commander��66   #��[  6n    � Cursor$
 Hand��6�   �� 5I      -   5        $ SoldierButton��5I      $��I'm a Soldier��64   #��[  6h   $
 Hand��6�   5K      �� 5N      $��
— OR —��6   $��28(�6*   $��Center=�68   $��Verdana)�6U   ���#838383$��0 50 0 0q�6   5P      5R      5T      5U      