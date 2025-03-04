# GPT3-API-Client-ASK

Application uses the OpenAI GPT-3 API to build a "ChatGPT-like" .net client app which can be ran from CLI, providing instant help to remember any command, script and more...
<br/>Supported platform: Windows

## Installation

- Download executeable [here](https://github.com/Guram-K/GPT3-API-Client-ASK/releases)
- Move config.json and ask.exe files to desired location (both files should be in the same folder)
- Add ask in windows path
  - Search for "Edit the system environment variables"
  - Click "Environment Variables..."
  - In "System variables" click "Path" and "Edit..."
  - Click "New" and paste path to where ask.exe was moved
  - Click "Ok"

## Generate API Key

- Go to [Open AI](https://beta.openai.com/)
- Create an account
- Drop down "Personal" on upper right side
- Click "View API Keys"
- Create new secret key and copy it to pass as a variable to ASK on first configuration

## Configure ASK

- open CLI
- type `ask -up -token your-token`

## Usage

- Open CLI
- To view available commands call `ask -help`
- To simply ask a question, write: `ask "your question"`
