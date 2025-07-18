import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://hikruapi-fbdshfg7hrbmeuh6.canadacentral-01.azurewebsites.net/api', // Replace with your actual base URL
  headers: {
    'Content-Type': 'application/json',
    // Add any other default headers here, e.g., Authorization
  },
});

const fetchPositions = async () => {
  try {
    const response = await axiosInstance.get('/positions');
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch positions');
  }
};

// A mock function to mimic making an async request for data
const fetchCount = (amount = 1): Promise<{ data: number }> =>
  new Promise<{ data: number }>(resolve =>
    setTimeout(() => {
      resolve({ data: amount })
    }, 500),
  )


export { fetchPositions, fetchCount }