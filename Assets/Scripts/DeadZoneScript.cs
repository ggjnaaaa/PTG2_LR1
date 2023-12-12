using UnityEngine;

//~~~~~~    Скрипт для геймобъекта Dead Zone    ~~~~~~//
// Проверяет пересечение своего колидера с объектами с тэгом "Игрок"
public class DeadZoneScript : MonoBehaviour
{
    public GameObject lose;
    public GameObject panel;
    public GameObject player;

    private void Update()
    {
        //~~~~~~    Обновление позиции зоны смерти (позиция зоны смерти по оси y остаётся прежней)    ~~~~~~//
        float temp = transform.position.y;
        Vector3 vec = player.transform.position - transform.position;
        vec.y = temp;
        transform.position = vec;

        //~~~~~~    На случай если игрок выпал, но зона и игрок не пересеклись    ~~~~~~//
        if (player.transform.position.y < transform.position.y)
            end();
    }

    private void OnTriggerEnter(Collider other)
    {
        //~~~~~~    Если пересечение произошло с объектомм с тэгом "игрок"    ~~~~~~//
        if (other.tag == "Player")
            end();
    }

    //~~~~~~    Включение меню проигрыша    ~~~~~~//
    private void end()
    {
        lose.SetActive(true);
        panel.SetActive(true);
    }
}
