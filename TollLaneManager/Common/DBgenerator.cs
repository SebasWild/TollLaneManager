using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TollLaneManager.Common
{
    ///Creates a new DB with associated tables, should it not exist yet.
    static class DBgenerator {
        //Static constructor, cannot take any parameters.
        static DBgenerator() {
            SQLiteConnection conn = new SQLiteConnection("Data Source=TollLaneManager.db");
            conn.Open();        //I pray that this does something.

            var command = conn.CreateCommand();

            //Creating the tables:
            //CREATE TABLE for accountholder....Modify this if there is some stuff to add.
            command.CommandText = "CREATE TABLE IF NOT EXISTS accountholder(id int PRIMARY KEY, firstname varchar(50), lastname varchar(50), phonenum varchar(20), country varchar(50), city varchar(50), street varchar(50), zip varchar(10), email varchar(100));";
            command.ExecuteNonQuery();
            //CREATE TABLE for account
            command.CommandText = "CREATE TABLE IF NOT EXISTS account(id int PRIMARY KEY, owner_ID int, FOREIGN KEY(owner_ID) REFERENCES accountholder(ID));";
            command.ExecuteNonQuery();

        }
    }
}
