   M S B A M L   `   `   `  ����D  @CardinalL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CardinalL.ViewsCardinalL.Views  5   	   (    "CardinalL.Views.RegistrationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CardinalL.Views     5   	     � Title$  RegistrationWindow��5      $	��600��6'   $	��500��64    � 
ResizeMode$ NoResize=�6@   ���#61515D.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��1��6   .+�5      �� $��1��6   $��0��6(   $��10q�65   $��30(�6B    �� TextAlignment$ Center=�6P   
�������Welcome to Cardinal6�   �� 5      $��5q�6   
�������$��20(�6;   Mail6O   �� 5      -   5         ��Name$ TextBox_Mail��5      $��5q�6,   ���#4C414A$��15(�6L   6\   �� 5      $��5q�6   
�������$��20(�6;   
Username6S   �� 5      -   5        $ TextBox_Username��5      $��5q�60   ���#4C414A$��15(�6P   6`   �� 5      $��5q�6   
�������$��20(�6;   Login6P   �� 5      -   5        $ TextBox_Login��5      $��5q�6-   ���#4C414A$��15(�6M   6]   �� 5      $��5q�6   
�������$��20(�6;   Phone6P   �� 5      -   5        $ TextBox_Phone��5      $��5q�6-   ���#4C414A$��15(�6M   6]   �� 5      $��5q�6   
�������$��20(�6;   
Password6S   G� 5      -   5         G�Name$ PassBox��5      $��5q�6+   ���#4C414A$��15(�6K   6[   �� 5      $��5q�6   
�������$��20(�6;   
Password6S   G� 5      -   5        $ PassBox2��5      $��5q�6,   ���#4C414A$��15(�6L   6\   � 5      $��5q�6   .+�5      �� -   5         ��Name$ TextBlockCapcha��5      $��20(�65   $��5,0,5,0q�6C   5+5=6Z   �� 5       -   5        $ TextBoxCapchaAnsw��5       $	��220��66   
����� �6V   5!      �� 5"      -	   5         ��Name$ Button_Regist��5"      $��1��6,   $��5q�6<   ���#0077FF$��20(�6x   .��6�   
Registrate6�   5$      5&      5'      