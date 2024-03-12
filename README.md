# AsynchronousDapperApp

## About
* C#, WinForm, MSSQL 2022, DevExpress(Report), Dapper
* 비동기처리, 동기처리 및 여러 RDBMS에 적용가능하도록 설계
* 클래스 라이브러리 프로젝트
* DB 프로젝트 생성 및 게시 방법
* `구조: form1, form2.. <---> Data <---> DbAccess <---> DB`

* [Simple C# Data Access with Dapper and SQL - Minimal API Project Part 1](https://youtu.be/dwMFg6uxQ0I?si=Nkf9Xj5p0ZtKXZZm)
* 조회수 197,563회  2021. 11. 22.
Minimal APIs are now the default in .NET 6. I thought that we should take some time and look at what they are, how they work, and what they might look like in the real world. To that end, we are going to spend two videos covering this topic. This video will cover setting up a SQL database and configuring Dapper for easy data access. We will set up a simple but full CRUD data layer so that when we build our minimal API in part two, we can concentrate on the API itself and not the setup. The great thing is that this lesson will work with almost any user interface, not just a minimal API. 

Part 2: Minimal API in .NET 6 Using Dapper an...  

## Environment
* IDE: Visual Studio 2022
* Language: C#
* Applied Project Template: .NET 8.0 (.Net WinForm(windows form))    
* NuGet  
    * Dapper
	* System.Data.SqlClient
* Third Party Libraries    
* DataBase: MS SQL 2022

## 작업
### winform project
	* 프로젝트명 AsynchronousDapper, 솔루션명 AsynchronousDapperApp
### SQL Server DataBase project 추가: DB 프로젝트 생성 및 게시 방법
	* 프로젝트명 AsynchronousDapper.UserDB
	* dbo 폴더 추가
		* Tables 폴더 추가
			* `Table` 추가
			* User
	* StoredProcedures 폴더 추가
		* `저장 프로시저` 추가
		* spUser_GetAll
		* spUser_GetById
		* spUser_Insert
		* spUser_Update
		* spUser_Delete
	* DataBase project에서 `스크립트` 추가
		* `배포 후 스크립트` 추가 => Script.PostDEployment.sql
		* 테이블에 삽입할 쿼리 작성
		```SQL
		if not exists (select 1 from dbo.[User])
		begin
			insert into dbo.[User] (FirstName, LastName)
			values ('Tim', 'Corey'),
			('Sue', 'Storm'),
			('John', 'Smith'),
			('Mary', 'Jones');
		end
		```
	* DataBase project에서 `게시` 선택
		* 편집에서 DB 인스턴스 선택
		* Database 이름 AsynchronousDapperUserDB
		* 스크립트 이름 AsynchronousDapper.UserDB.sql => 자동으로 생성됨
		* Profile로 저장
	* 그러면 프로젝트에 AsynchronousDapper.UserDB.publish.xml파일로 존재
	* .GitIgnore를 통해 저장소에 빠지므로 마우스 우측클릭-> git ->`소스 제어에 무시된 파일 추가`를 통해 추가한다.
	* AsynchronousDapper.UserDB.publish.xml을 더블클릭하면 게시화면을 호출할 수 있으며,
	* 게시 한다.
	* Database가 제대로 생성 되었는지 확인한다.
### 클래스 라이브러리 프로젝트 추가
	* 프로젝트명 AsynchronousDapper.DataAccess
### 솔루션 선택(클래스 라이브러리 프로젝트에서는 안먹혀서 생략 -> 아래 다른 방법 사용)
	* 추가 - new EditorConfig, 추가가 안되어 프로젝트에서 추가하여 이동함
	* EditorConfig에서 코드 스타일 -> 코드블럭 기분 설정-> 네임스페이스 선언 = `파일범위 지정됨`으로 변경
	* `파일범위 지정됨`은 namespace AsynchronousDapper.DataAccess.Models {}=> using namespace AsynchronousDapper.DataAccess.Models; 로 변경시켜주므로 소스가 깔끔해짐
### AsynchronousDapper.DataAccess 프로젝트 선택
	* `구조: form1, form2.. <---> Data <---> DbAccess <---> DB`
	
	* Models 폴더 추가: Entity 클래스 모음
	* DbAccess 폴더 추가: DB와 직접 소통(MSSQL, ORACLE, SQLite등), SaveData(),LoadData()
	* Data 폴더 추가: Form은 Data 폴더를 통해 DB와 통신,  DbAccess를 통해 DB에 Data를 Insert, Update, Delete, GetAll 작업
	* Nuget 추가
		* [x] Dapper
		* [x] System.Data.SqlClient
		* [ ] Microsoft.Extensions.Configuration.Abstractions : appsettings.json(Asp.net에서 사용) 과 통신, winform에서는 app.setting과 통신하므로 필요 없음
	* Models 폴더
		* UserModel 클래스 추가: Table Entity
	* DbAccess 폴더 : DB와 직접 소통
		* SqlDataAccess 클래스 추가: MS SQL과 직접 대화하는 기능
## Tip
* 메서드 코딩시 매개변수가 길 경우 `Ctrl + .` 으로 인델리전트를 실행해서
* `모든 매개 변수 래핑` 에서 원하는 래핑을 선택하면 된다.
* 클래스에서 인터페이스 추출은 클래스명에 커서를 놓고 `Ctrl + .` 을 통해 할 수 있다.
