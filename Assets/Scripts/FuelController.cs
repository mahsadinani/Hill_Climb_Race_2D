using UnityEngine;
using UnityEngine.UI; //canvas - text - font and others 
public class FuelController : MonoBehaviour
{
    public static FuelController instance;
    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maximumFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;
    private float _currentFuelAmount;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        _currentFuelAmount = _maximumFuelAmount;
        UpdateUI();

    }
    private void Update()
    {
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        // you may wanna cheat :) 
        // but even if your car doesnt move , it still drains fuel 
        UpdateUI();
    }
    private void UpdateUI() // we define this method 
    {
        _fuelImage.fillAmount = (_currentFuelAmount / _maximumFuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }
}
