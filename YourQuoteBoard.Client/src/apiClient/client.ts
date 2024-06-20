// client.ts
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7220',
  headers: {
    'Content-Type': 'application/json',
  },
  withCredentials: true,
  timeout: 10000,
});

const apiClientFile = axios.create({
  baseURL: 'https://localhost:7220',
  headers: {
    'Content-Type': 'multipart/form-data',
  },
  withCredentials: true,
  timeout: 10000,
});

export default apiClient;
