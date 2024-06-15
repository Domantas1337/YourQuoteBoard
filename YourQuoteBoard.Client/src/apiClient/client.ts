// client.ts
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7220',
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

export default apiClient;
