using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudentManager : MonoBehaviour
{
    [SerializeField] private InputField idInput;  
    [SerializeField] private Button searchBtn;    
    [SerializeField] private Text resultText;     

    [Serializable]  
    private class Student
    {
        public string studentName;
        public string ID;
        public string studentBirthday;
        public int studentAge;
    }

    private Student[] students;

    void Start()  
    {
        
        students = new Student[]
        {
            new Student { studentName = "Floyd Escuadra", ID = "24-756", studentBirthday = "Dec 19, 2007", studentAge = 17 },
            new Student { studentName = "Arjan Manzano", ID = "24-752", studentBirthday = "Oct 12, 2007", studentAge = 17 },
            new Student { studentName = "Juan Miguel Inez", ID = "24-731", studentBirthday = "April 10, 2007", studentAge = 18 },
            new Student { studentName = "Jon Miguel Esquivel", ID = "24-744", studentBirthday = "June 28, 2008", studentAge = 16 },
            new Student { studentName = "Mikel Reuel Ramos", ID = "24-716", studentBirthday = "Nov 11, 2007", studentAge = 17 }
        };

        if (searchBtn != null)
            searchBtn.onClick.AddListener(SearchId);
    }

    private void SearchId()  
    {
        if (string.IsNullOrEmpty(idInput.text))
        {
            resultText.text = "Please enter an ID";  
            return;
        }

        string enteredId = idInput.text.Trim();
        Student student = Array.Find(students, student => student.ID == enteredId);

        if (student != null)
        {
            resultText.text = $"Name: {student.studentName}\n" +
                              $"Birthday: {student.studentBirthday}\n" +
                              $"Age: {student.studentAge}\n" + 
                              $"ID number: {student.ID}\n";
        }
        else
        {
            resultText.text = "No matching ID found";
        }
    }
    private void OnDestroy()  
    {
        if (searchBtn != null)
            searchBtn.onClick.RemoveListener(SearchId);
    }
}
