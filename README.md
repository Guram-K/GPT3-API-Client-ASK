# GPT3-API-Client-ASK

Application uses the OpenAI GPT-3 API to build a "ChatGPT-like" .net client app which can be ran from CLI, providing instant help to remember any command, script and more..
Supported platform: Windows

## Installation

- Download executeable [here](https://github.com/Guram-K/GPT3-API-Client-ASK/releases)
- Move config.json and ask.exe files to desired locations
- Add ask in windows path
  - Search for "Edit the system environment variables"
  - Click "Environment Variables..."
  - In "System variables" click "Path" and "Edit..."
  - Click "New" and paste path to where ask.exe was moved
  - Click "Ok"

## Usage

- To view available commands call `ask -help`
- To simply ask a question, write: `ask "your question"`
