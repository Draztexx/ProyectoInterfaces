   M S B A M L   `   `   `  ����  
Proyecto05    Proyecto05.Administrar   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Administrar��5   	   $	��600��6   $
��1000��6*   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataGrid1��5         AutoGenerateColumns$ False��6&   $
��Left=�6B   $	��Top=�6]   $
��1000��6u   $	��600��6�      CanUserAddRows$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Usuario��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
username+6S     5      $ Email��6%   $	 300 6N    64   �� *email+6N     5      $ 
Puntuacion��6%   $	 200 6T    69   �� *puntos+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Acciones��6)   $	 200 6;   	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� -   5        $��	Modificar��5   )   $��75��6=   6H   �� 5   "   -   5        $��Eliminar��5   )   $��75��6<   6G   5      5      5         RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property � �� �� Value
 ��ح�63   5       5"      5#      5%      