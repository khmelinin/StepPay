   M S B A M L   `   `   `  ����C  ?STEP_PAY, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:STEP_PAY.ViewsSTEP_PAY.Views  5          STEP_PAY.Views.CardPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:STEP_PAY.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      ��  �� SelectedValuePath$ Number��5      $	��206��5       �� ItemStringFormat$  ��5      ��5      �� *Cards+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedValue 5      �� *SelectedCard+��5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5   "   �� 5   "   .+�5      �� $��12(�6$   ��62   �� *Title+�� 5      $��12(�6$   $��1��62   ��6B   �� *Money+5       5!      5#      �� 5$      $��Select Card��6    � Cursor$
 Hand��6N   ��6+   �� *DropDownClosed+6N   5%      �� 5&   
   $��1��5'      $ 
Horizontal=�5(      $��Center=�5)      .+�5*      �� 
�������$
 Hand��5,   %   $��0q�5-      $
��Auto��6   
�������$��0,0,0,1q�5.   $   ��5+      �� *ShowCardCommand2+.��5/      ]� .+�50      ��  �� CornerRadius$ 6��51      
�������$	��146��53      
�������$��2q�55      $	��Top=�56      ._�57      �� $��Center=�58      ��59      �� *	CardName2+$ PropertyChanged=�5;      5<      5=      �� 5>      
�������$
��Auto��5@   %   $
 Hand��5A      $��0q�5B      $
��Auto��6   
�������$��0,2,0,1q�5C   &   ��5?      �� *ShowCardCommand+.��5D      ]� .+�5E      �� $ 6��5F      
�������
�������$��2q�5I      $	��Top=�5J      ._�5K      �� .+�5L      �� $��	10 10 0 0q�5M   !   $��14(�5N   !   	 �� Padding$	 0 0 8 0q�5O   !   ��5P   !   �� *
CardName+$ PropertyChanged=��� 5Q      $��16(�5R   !   $
��Bold"�5S   !   $	 30 30 30 10q�5T   !   $��Center=�5U   !   $��Center=�5V   !   ��5W   !   �� *
NumberCard+$ PropertyChanged=��� 5X      $��DemiBold"�5Z   !   $��Center=�5[   !   ��5Y   !   �� *	DateExp+$ PropertyChanged=�5[   !   �� 5]      $��10q�5_   !   $��13(�5`   !   $��Right=�5a   !   ��5^   !   �� *Money+$ PropertyChanged=�5a   !   5b      5c      5d      5e      5f      �� 5g   
   $��2��5i      $ Vertical=�6   $��Center=�5j      $��Center=�5k      y�5h      �� *
ShowCard+$ PropertyChanged=�.+�5l      �� $3��-Показать в другой валюте��5m      $��10q�5o      $	��0 4q�6"   ��5n      �� *ChangeCurrencyCommand+5o   "   �� 5p      $-��'Статистика рассходов��5q      $��10q�5r      $	��0 4q�6"   5s      5t      5u      