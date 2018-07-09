using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;
using System;

namespace World.Models
{
    public class Country
    {
        private string _name;
        private string _continent;
        private int _population;

        public Country(string name, string continent, int population)
        {
            _name = name;
            _continent = continent;
            _population = population;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetContinent(string continent)
        {
            _continent = continent;
        }

        public string GetContinent()
        {
            return _continent;
        }

        public void SetPopulation(int population)
        {
            _population = population;
        }

        public int GetPopulation()
        {
            return _population;
        }


        public static List<Country> GetAll()
        {
          List<Country> allCountries = new List<Country> { };
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM country";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string countryName = rdr.GetString(1);
            string countryContinent = rdr.GetString(2);
            int countryPopulation = rdr.GetInt32(3);
            Country newCountry = new Country(countryName, countryContinent, countryPopulation);
            allCountries.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allCountries;
        }

        public static List<Country> GetSort(string sortField, string sortType)
        {
            List<Country> allCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country ORDER BY " + sortField + sortType + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string countryName = rdr.GetString(1);
                string countryContinent = rdr.GetString(2);
                int countryPopulation = rdr.GetInt32(3);
                Country newCountry = new Country(countryName, countryContinent, countryPopulation);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }
    }
}
