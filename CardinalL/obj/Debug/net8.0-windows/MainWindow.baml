   M S B A M L   `   `   `  ����D  @CardinalL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CardinalL	CardinalL  5   	       CardinalL.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CardinalL     5   	     � Title$  
MainWindow��5      $	��450��6    $	��800��6-   $	��450��69   $	��800��6I   ���#262C2B.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.3* �6    � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      �� 5      $
��0.4* �6   .+�5   
   �� $��1��6   $��0��6$   $��10q�61   $��30(�6>    �� TextAlignment$ Center=�6L   
�������Welcome to Cardinal6�   �� 5   
   $��1��6   $��0,1,0,95q�6"   $��2��64   $��1��6E   .+�5      �� $��5q�6   
�������$��20(�6;   Mail or username6[   �� 5      -   5         ��Name$ TextBox_Username��5      $��5q�60   ���#4C414A$��15(�6P   6`   �� 5      $��5q�6   
�������$��20(�6;   
Password6S   G� 5      -   5         G�Name$ PassBox��5      $��5q�6+   ���#4C414A$��15(�6K   6[   �� 5      $��5q�6   $ Center=�6#   $��15(�6:   	Forgot?6Q   � 5       5      �� 5      �� 5       5!      �� 5"      $��30 �6$   .+�5$      �� -   5        $��0��5$      $��5,0,15,0q�6)   ���#0077FF$��20(�6l   .��6z   	Sing in6�   �� 5%      -   5        $��1��5%      $��15,0,5,0q�6)   ���#0077FF$��20(�6l   .��6z   	Sing up6�   5&      5'      5)      5*      