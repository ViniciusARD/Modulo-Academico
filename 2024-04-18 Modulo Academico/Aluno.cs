using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Aluno
{
    // Campos privados que armazenam os dados do aluno
    private int id;
    private string nome;
    private string rgm;
    private DateTime dataNascimento;
    private string curso;
    private int bolsista;
    private string rg;
    private string genero;

    // Construtor que inicializa os campos da classe com os valores passados como parâmetros
    public Aluno(string _nome, string _rgm, DateTime _dataNascimento, string _curso, int _bolsista, string _rg, string _genero)
    {
        nome = _nome;
        rgm = _rgm;
        dataNascimento = _dataNascimento;
        curso = _curso;
        bolsista = _bolsista;
        rg = _rg;
        genero = _genero;
    }

    // Construtor padrão que inicializa os campos com valores padrão
    public Aluno()
    {
        nome = "";
        rgm = "";
        dataNascimento = DateTime.MinValue;
        curso = "";
        bolsista = 0;
        rg = "";
        genero = "";
    }

    //Gets e Sets dos campos
    public int GetId()
    {
        return id;
    }

    public void SetId(int valor)
    {
        id = valor;
    }

    public string GetNome()
    {
        return nome;
    }

    public void SetNome(string valor)
    {
        nome = valor;
    }

    public string GetRgm()
    {
        return rgm;
    }

    public void SetRgm(string valor)
    {
        rgm = valor;
    }

    public DateTime GetDataNascimento()
    {
        return dataNascimento;
    }

    public void SetDataNascimento(DateTime valor)
    {
        dataNascimento = valor;
    }

    public string GetCurso()
    {
        return curso;
    }

    public void SetCurso(string valor)
    {
        curso = valor;
    }

    public int GetBolsista()
    {
        return bolsista;
    }

    public void SetBolsista(int valor)
    {
        bolsista = valor;
    }

    public string GetRg()
    {
        return rg;
    }

    public void SetRg(string valor)
    {
        rg = valor;
    }

    public string GetGenero()
    {
        return genero;
    }

    public void SetGenero(string valor)
    {
        genero = valor;
    }
}
