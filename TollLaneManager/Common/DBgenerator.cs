using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AutomatedRoadTollingSystem.Common
{
    ///Creates a new DB with associated tables, should it not exist yet.
    static class DBgenerator {
        /// <summary>
        /// Generate a new instance of the DB.
        /// Will only create new tables if they do not exist yet.
        /// 
        /// 
        /// Search for .db files in the project directory. If someone makes changes to the below code, search for TollLaneManager.db files in the project dir and delete them. They will be recreated on project start.
        /// </summary>
        public static void initDB() {
            SQLiteConnection conn = new SQLiteConnection("Data Source=TollLaneManager.db");
            conn.Open();        //I pray that this does something.

            var command = conn.CreateCommand();
            //I'm not handling deletes at all in the below statements!

            //Creating the tables:
            //CREATE TABLE for accountholder....Modify this if there is some stuff to add.
            command.CommandText = "CREATE TABLE IF NOT EXISTS accountholder(id int PRIMARY KEY, firstname varchar(50), lastname varchar(50), phonenum varchar(20), country varchar(50), city varchar(50), street varchar(50), zip varchar(10), email varchar(100));";
            command.ExecuteNonQuery();
            //CREATE TABLE for account
            command.CommandText = "CREATE TABLE IF NOT EXISTS account(id int PRIMARY KEY, owner_ID int, balance decimal(10,2), FOREIGN KEY(owner_ID) REFERENCES accountholder(id));";
            command.ExecuteNonQuery();
            //CREATE TABLE for tying accounts to license plates
            //We can have multiple license plates per account. 
            command.CommandText = "CREATE TABLE IF NOT EXISTS register(account int PRIMARY KEY, plateNo varchar(10), FOREIGN KEY(account) REFERENCES account(id));";
            command.ExecuteNonQuery();
            //Possible TODO: table to store lanes....

            conn.Close();

            fillTables();       //Fill in some values
        }
        /// <summary>
        /// Fill tables with some dummy data.
        /// 
        /// Note: this does not do any checking if the table has been created first. It errors out if the tables do not exist.
        /// </summary>
        private static void fillTables()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=TollLaneManager.db");
            conn.Open();        //I pray that this does something.

            var command = conn.CreateCommand();

            // DELETE FROM TABLES
            command.CommandText = "Delete FROM register;"; // Remove all the info before the table is populated again
            command.ExecuteNonQuery();
            command.CommandText = "Delete FROM account;"; // Remove all the info before the table is populated again
            command.ExecuteNonQuery();
            command.CommandText = "Delete FROM accountholder;"; // Remove all the info before the table is populated again         
            command.ExecuteNonQuery();

            //INSERT INTO for accountholder
            command.CommandText = "INSERT INTO accountholder VALUES(0, 'Sebastian', 'Wild', '6095047826', 'USA', 'Glassboro', 'Williams St.', '08028', 'wilds62@students.rowan.edu');";
            command.CommandText = "INSERT INTO accountholder VALUES(1, 'Frank', 'Staas', '6094055772', 'USA', 'Haddonfield', 'Williams St.', '', '');";
            command.CommandText = "INSERT INTO accountholder VALUES(2, 'Carl', 'Johns', '', 'USA', 'Glassboro', 'Williams St.', '08028', '');";
            command.CommandText = "INSERT INTO accountholder VALUES(3, 'Lisa', 'Max', '', 'USA', 'Glassboro', 'Williams St.', '08028', '');";
            command.ExecuteNonQuery();
           
            //INSERT INTO for account          
            command.CommandText = "INSERT INTO account VALUES(0, 0, 1337.00);";
            command.CommandText = "INSERT INTO account VALUES(1, 1, 4311.00);";
            command.CommandText = "INSERT INTO account VALUES(2, 2, 4474.00);";
            command.CommandText = "INSERT INTO account VALUES(3, 3, 4467.00);";
            command.ExecuteNonQuery();
            
            //INSERT INTO for register
            command.CommandText = "INSERT INTO register VALUES(0, 'QWERTY');";
            command.CommandText = "INSERT INTO register VALUES(1, 'JDIELS');";
            command.CommandText = "INSERT INTO register VALUES(2, '1000DD');";
            command.CommandText = "INSERT INTO register VALUES(3, 'JFED90');";
            command.ExecuteNonQuery();
        }
    }
}
