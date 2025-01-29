public class Hilka : GivesBuff
{
    private int _amountHeal = 30;

    protected override void Affect(IBuffPicker buffPicker) => 
        buffPicker.AddHealth(_amountHeal);
}
