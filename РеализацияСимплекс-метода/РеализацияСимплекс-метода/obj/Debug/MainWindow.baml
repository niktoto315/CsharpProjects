   M S B A M L   `   `   `  ����l  hРеализацияСимплекс-метода, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:РеализацияСимплекс_метода1РеализацияСимплекс_метода  5   	   B    <РеализацияСимплекс_метода.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qlocal?clr-namespace:РеализацияСимплекс_метода     5   	   -   5          � Title$!  Симплекс-метод��5   	   $��640px��6    $��300px��6.    � 
ResizeMode$ CanMinimize=�6=   .��5	      � -   5         �Name$ maingrid��5	      .+�5   
   �� $
��Wrap=�6   $%��Число переменных��6(   $
��Left=�6@   $	��Top=�6[   $	��110��6s   $��20��6   $��	10,10,0,0q�6�   �� 5   
   -   5         ��Name$
 CMBn��5      $
��Left=�6!   $	��Top=�6<   $��40��6T   $��20��6_   $��
120,10,0,0q�6k   .@�5      �� $��2��6   �� 5      $��3��6   �� 5      $��4��6   �� 5      $��5��6   5      �� 5   
   $
��Wrap=�6   $'��!Число ограничений��6(   $
��Left=�6A   $	��Top=�6\   $	��110��6t   $��20��6�   $��
170,10,0,0q�6�   �� 5   
   -   5        $
 CMBm��5      $
��Left=�6!   $	��Top=�6<   $��40��6T   $��20��6_   $��
290,10,0,0q�6k   .@�5      �� $��2��6   �� 5      $��3��6   �� 5      $��4��6   �� 5      $��5��6   5      �� 5   
   -   5         ��Name$	 CB1��5      $$��Максимизировать��6    $
��Left=�6:   $	��Top=�6U   $	��200��6m   $��20��6y   $��
340,10,0,0q�6�    d� 	IsChecked$
 TrueY�6�   �� 5   
   -   5         ��Name$ AimFun��5      $��Center=�6%   $	��Top=�6B   $	��600��6Z   $��30��6f   $��
10,50,10,0q�6r    �� Orientation$ 
Horizontal=�6�   A� 5!   
   -   5         A�Name$ SystemLimits��5!      $
��Left=�6,   $	��Top=�6G   $	��600��6_   $	��120��6k   $��
12,90,0,50q�6x   �� 5#   
   -   5        	 ��Name$	 Result��5#      $��Вычислить��6!   $��Center=�65   $��Bottom=�6R   $��
10,0,10,10q�6m   $	��600��6�   $��30��6�   6�   5$      5%      