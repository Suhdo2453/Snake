
using System;

public interface ICaculatorController
{
    void DisplayResults(float result);
    void UpdateText(string text);
    void OnAdditionButtonClick();
    void OnSubtractionButtonClick();
    void OnMultiplicationButtonClick();
    void OnDivisionButtonClick();
    void OnNormalButtonClick(float value);
    void OnFocusInputField(string arg0);
}
