   M S B A M L   `   `   `  ����E  AProyecto05, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Proyecto05
Proyecto05  5   	   !    Proyecto05.AdministrarTemas   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Proyecto05     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ AdministrarTemas��5	   	   $	��600��6"   $
��1000��6/   .��5
      � .+�5   
   �� $��40,15,40,483q�6    �� Orientation$ 
Horizontal=�6+   .+�5      �� -   5         ��Name$ 	TBKNombre��5      $	��600��6+   $��Listado de Temas��67   $��18(�6O   $��Center=�6]    �� TextAlignment$ Center=�6x   �� 5      -   5         ��Name$ 
BTNAgregar��5      $��52��6)   $	��215��65   $��Agregar Tema��6A   $��20(�6X   6f   5      � 5   
   $��10,101,10,10q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns$ False��6)   $
��Left=�6E   $��Center=�6`   $	��970��6{   $	��453��6�      CanUserAddRows$ False��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Nombre��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
nombretema+6X     5      $
 Descripcion��6)   $	 500 6^    6>   �� *descripcion+6^     5      $
 Duracion��6)   $	 100 6V    6;   �� *tiempo+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Acciones��6-   $	 150 6?      CellTemplate 5      �� 5      .R�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� -   5        $��	Modificar��5   -   $��75��6A   6L   �� 5   &   -   5        $��Eliminar��5   -   $��75��6@   
 � Tag 6i   �� 5   #   5      5          RowStyle 5"      �� 5#       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5$      ��  �� Property � �� �� Value
 ��ح�67   5%      5'      5(      5+      5,      