   M S B A M L   `   `   `  ���� l  hРеализацияСимплекс-метода, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:РеализацияСимплекс_метода1РеализацияСимплекс_метода  B    <РеализацияСимплекс_метода.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Qlocal?clr-namespace:РеализацияСимплекс_метода     -     � Title$!  Симплекс-метод��$��640px��$��300px�� � 
ResizeMode$ CanMinimize=�.��� -    �Name$ maingrid��.+��� $
��Wrap=�$%��Число переменных��$
��Left=�$	��Top=�$	��110��$��20��$��	10,10,0,0q��� -    ��Name$
 CMBn��$
��Left=�$	��Top=�$��40��$��20��$��
120,10,0,0q�.@��� $��2���� $��3���� $��4���� $��5���� $
��Wrap=�$'��!Число ограничений��$
��Left=�$	��Top=�$	��110��$��20��$��
170,10,0,0q��� -   $
 CMBm��$
��Left=�$	��Top=�$��40��$��20��$��
290,10,0,0q�.@��� $��2���� $��3���� $��4���� $��5���� -    ��Name$	 CB1��$$��Максимизировать��$
��Left=�$	��Top=�$	��200��$��20��$��
340,10,0,0q� d� 	IsChecked$
 TrueY��� -    ��Name$ AimFun��$��Center=�$	��Top=�$	��600��$��30��$��
10,50,10,0q� �� Orientation$ 
Horizontal=�A� -    A�Name$ SystemLimits��$
��Left=�$	��Top=�$	��600��$	��120��$��
12,90,0,50q��� -   	 ��Name$	 Result��$��Вычислить��$��Center=�$��Bottom=�$��
10,0,10,10q�$	��600��$��30��