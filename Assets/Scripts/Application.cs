using UnityEngine;
public class Application : MonoBehaviour
{
    public Model model;
    public View view;
    public Controller controller;

    private void Start()
    {
        model = GetComponentInChildren<Model>();
        view = GetComponentInChildren<View>();
        controller = GetComponentInChildren<Controller>();
    }
}
